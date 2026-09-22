using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Data
{
	/// <summary>
	/// In-memory store and organiser for local events and announcements.
	/// Demonstrates the Part 2 technical requirements:
	///   - SortedDictionary&lt;DateTime, List&lt;Event&gt;&gt; keeps events
	///     chronologically ordered for fast date-range lookups.
	///   - Dictionary&lt;string, List&lt;Event&gt;&gt; is the hash table used
	///     to retrieve all events for a given category in O(1).
	///   - HashSet&lt;string&gt; / HashSet&lt;DateTime&gt; hold the unique
	///     categories and dates used to populate filter controls.
	///   - A Queue&lt;Event&gt; models the first-in-first-out feed of newly
	///     published announcements.
	///   - A Stack&lt;Event&gt; tracks the events a resident has most
	///     recently viewed (last viewed = first shown).
	///   - A PriorityQueue&lt;Event, DateTime&gt; (see PriorityQueue.cs)
	///     always gives O(log n) access to the single soonest event.
	/// </summary>
	public static class EventRepository
	{
		private static readonly SortedDictionary<DateTime, List<Event>> _eventsByDate = new SortedDictionary<DateTime, List<Event>>();
		private static readonly Dictionary<string, List<Event>> _eventsByCategory = new Dictionary<string, List<Event>>(StringComparer.OrdinalIgnoreCase);
		private static readonly HashSet<string> _categories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		private static readonly HashSet<DateTime> _eventDates = new HashSet<DateTime>();
		private static readonly Queue<Event> _announcementFeed = new Queue<Event>();
		private static readonly Stack<Event> _recentlyViewed = new Stack<Event>();
		private static readonly List<Event> _allEvents = new List<Event>();

		public static IReadOnlyCollection<string> Categories => _categories;

		static EventRepository()
		{
			Seed();
		}

		private static void Seed()
		{
			var today = DateTime.Today;
			var seedData = new (string Title, string Category, int DaysFromNow, string Location, string Description)[]
			{
				("Ward 12 Community Clean-Up",        "Environment",     2,  "Riverside Park",            "Join residents for a morning of litter collection and recycling drop-off along the river bank."),
				("Free Health & Wellness Screening",  "Health",          4,  "Ward 12 Community Hall",    "Blood pressure, glucose and HIV testing offered free of charge by the Department of Health."),
				("Youth Skills Development Workshop", "Youth",           6,  "Library Auditorium",        "CV writing, interview skills and digital literacy training for residents aged 18-25."),
				("Municipal Budget Public Hearing",    "Governance",      8,  "Civic Centre",               "Residents can review and comment on the draft municipal budget for the coming financial year."),
				("Load-Shedding Schedule Briefing",    "Utilities",       9,  "Online (Municipal Website)","An update on the current load-shedding stages and schedule changes affecting the ward."),
				("Neighbourhood Watch Safety Meeting", "Safety",         11,  "Ward 12 Community Hall",    "Monthly meeting to coordinate patrols and discuss recent safety concerns in the area."),
				("Heritage Day Cultural Festival",     "Culture",        14,  "Freedom Square",             "Music, food stalls and craft markets celebrating the diverse cultures of the municipality."),
				("Storm Water Drain Maintenance",      "Utilities",      15,  "Main Road & 5th Avenue",     "Planned maintenance work; expect temporary lane closures during working hours."),
				("Municipal Soccer Tournament",         "Sports",         18,  "Ward 12 Sports Grounds",     "Round-robin soccer tournament between local wards, followed by a prize-giving ceremony."),
				("Indigent Support Registration Drive", "Governance",     20,  "Civic Centre",               "Assistance for qualifying households to register for the indigent support and rebate programme."),
				("Tree Planting Day",                   "Environment",    22,  "Freedom Square",             "Community tree-planting initiative in partnership with the Department of Forestry."),
				("Public Library Reading Club Launch",  "Culture",        25,  "Library Auditorium",         "A new weekly reading club for children and teenagers, with refreshments provided."),
				("Water Conservation Awareness Day",    "Utilities",      27,  "Riverside Park",             "Demonstrations on rainwater harvesting and greywater reuse for households and businesses."),
				("Senior Citizens Wellness Day",        "Health",         29,  "Ward 12 Community Hall",     "Free check-ups, exercise classes and a social lunch for residents aged 60 and older."),
				("Small Business Funding Info Session", "Governance",     32,  "Civic Centre",               "Information on municipal grants and provincial funding available to local small businesses."),
			};

			int id = 1;
			foreach (var e in seedData)
			{
				AddEvent(new Event(id++, e.Title, e.Category, today.AddDays(e.DaysFromNow), e.Location, e.Description));
			}
		}

		private static void AddEvent(Event ev)
		{
			_allEvents.Add(ev);

			// Sorted dictionary keyed by date (date-only key so same-day events group together)
			var dateKey = ev.Date.Date;
			if (!_eventsByDate.TryGetValue(dateKey, out var dateList))
			{
				dateList = new List<Event>();
				_eventsByDate[dateKey] = dateList;
			}
			dateList.Add(ev);

			// Hash table keyed by category
			if (!_eventsByCategory.TryGetValue(ev.Category, out var catList))
			{
				catList = new List<Event>();
				_eventsByCategory[ev.Category] = catList;
			}
			catList.Add(ev);

			// Sets of unique categories / dates, used to populate filter controls
			_categories.Add(ev.Category);
			_eventDates.Add(dateKey);

			// FIFO feed of newly published announcements
			_announcementFeed.Enqueue(ev);
		}

		/// <summary>All events, ordered chronologically via the SortedDictionary.</summary>
		public static List<Event> GetAllEventsChronological()
		{
			return _eventsByDate.Values.SelectMany(list => list).OrderBy(e => e.Date).ToList();
		}

		/// <summary>O(1) hash-table lookup of every event in a given category.</summary>
		public static List<Event> GetByCategory(string category)
		{
			return _eventsByCategory.TryGetValue(category, out var list) ? list.ToList() : new List<Event>();
		}

		/// <summary>
		/// Builds a fresh min-heap priority queue (priority = date) and pops
		/// it to return the single soonest upcoming event.
		/// </summary>
		public static Event GetNextUpcomingEvent()
		{
			var pq = new PriorityQueue<Event, DateTime>();
			foreach (var ev in _allEvents)
			{
				if (ev.Date >= DateTime.Now) pq.Enqueue(ev, ev.Date);
			}
			return pq.Count > 0 ? pq.Dequeue() : null;
		}

		/// <summary>Drains the announcement Queue (FIFO) into an ordered list for display.</summary>
		public static List<Event> DrainAnnouncementFeed(int max)
		{
			var result = new List<Event>();
			var tempQueue = new Queue<Event>(_announcementFeed); // don't destroy the real feed
			while (tempQueue.Count > 0 && result.Count < max)
			{
				result.Add(tempQueue.Dequeue());
			}
			return result;
		}

		/// <summary>Pushes an event a resident just opened onto the "recently viewed" Stack.</summary>
		public static void MarkViewed(Event ev)
		{
			_recentlyViewed.Push(ev);
		}

		/// <summary>Peeks the last few recently-viewed events (LIFO order) without popping them.</summary>
		public static List<Event> GetRecentlyViewed(int max)
		{
			return _recentlyViewed.Take(max).ToList();
		}

		/// <summary>
		/// Filters events by an optional keyword, category and date range.
		/// Uses the category hash table when a category is supplied
		/// (narrowing the search space before applying the other filters),
		/// and the sorted-by-date structure otherwise.
		/// </summary>
		public static List<Event> Search(string keyword, string category, DateTime? from, DateTime? to)
		{
			IEnumerable<Event> source;
			if (string.IsNullOrEmpty(category) || category == "All Categories")
			{
				source = GetAllEventsChronological();
			}
			else
			{
				source = GetByCategory(category).OrderBy(e => e.Date);
			}

			if (!string.IsNullOrWhiteSpace(keyword))
			{
				source = source.Where(e =>
					e.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
					e.Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
					e.Location.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
			}

			if (from.HasValue) source = source.Where(e => e.Date.Date >= from.Value.Date);
			if (to.HasValue) source = source.Where(e => e.Date.Date <= to.Value.Date);

			return source.ToList();
		}
	}
}