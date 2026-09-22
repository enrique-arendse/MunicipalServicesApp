using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Data
{
	/// <summary>
	/// Implements the "Additional Recommendation Feature". Every search a
	/// resident performs is logged against the category it targeted, using
	/// a Dictionary&lt;string, int&gt; as a simple frequency table. When
	/// recommendations are requested, the categories are ranked with the
	/// PriorityQueue (highest search frequency = highest priority) and
	/// events from the resident's favourite categories - that were not
	/// already part of their last search results - are suggested.
	/// </summary>
	public class RecommendationEngine
	{
		private readonly Dictionary<string, int> _categorySearchCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		private readonly List<string> _searchHistory = new List<string>();

		/// <summary>Records a search so future recommendations can learn from it.</summary>
		public void RecordSearch(string keyword, string category)
		{
			if (!string.IsNullOrWhiteSpace(keyword))
			{
				_searchHistory.Add(keyword.Trim());
			}

			if (!string.IsNullOrWhiteSpace(category) && category != "All Categories")
			{
				_categorySearchCounts[category] = _categorySearchCounts.TryGetValue(category, out var count) ? count + 1 : 1;
			}
			else if (!string.IsNullOrWhiteSpace(keyword))
			{
				// No explicit category filter was used - infer interest from
				// which categories the keyword actually matched.
				foreach (var ev in EventRepository.GetAllEventsChronological())
				{
					bool matches = ev.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
								   ev.Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
					if (matches)
					{
						_categorySearchCounts[ev.Category] = _categorySearchCounts.TryGetValue(ev.Category, out var c) ? c + 1 : 1;
					}
				}
			}
		}

		public bool HasSearchHistory => _categorySearchCounts.Count > 0;

		/// <summary>
		/// Ranks searched categories by frequency (using the priority queue
		/// as a max-heap via a negated priority) and returns up to
		/// <paramref name="max"/> upcoming events from the top categories
		/// that are not already present in <paramref name="exclude"/>.
		/// </summary>
		public List<Event> GetRecommendations(IEnumerable<Event> exclude, int max = 5)
		{
			var excludeIds = new HashSet<int>(exclude.Select(e => e.Id));
			var recommendations = new List<Event>();

			var categoryQueue = new PriorityQueue<string, int>();
			foreach (var kvp in _categorySearchCounts)
			{
				categoryQueue.Enqueue(kvp.Key, -kvp.Value); // negate: highest count dequeues first
			}

			while (categoryQueue.Count > 0 && recommendations.Count < max)
			{
				string category = categoryQueue.Dequeue();

				var candidates = EventRepository.GetByCategory(category)
					.Where(e => e.Date >= DateTime.Now && !excludeIds.Contains(e.Id))
					.OrderBy(e => e.Date);

				foreach (var candidate in candidates)
				{
					if (recommendations.Count >= max) break;
					if (recommendations.Any(r => r.Id == candidate.Id)) continue;
					recommendations.Add(candidate);
					excludeIds.Add(candidate.Id);
				}
			}

			return recommendations;
		}
	}
}
