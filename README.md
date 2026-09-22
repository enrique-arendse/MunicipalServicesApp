# Municipal Services Application - Parts 1 & 2

AAPD7112 (Advanced Application Development) - Portfolio of Evidence

## What this is

A C# .NET Framework (targeting .NET Framework 4.8) Windows Forms desktop
application for South African municipal residents.

- **Part 1 - Report Issues:** residents can report an issue (location,
  category, description, optional attachment), with a real-time gamified
  progress/feedback engagement feature.
- **Part 2 - Local Events and Announcements:** residents can browse,
  search and filter upcoming municipal events, see a "Next up" spotlight
  and a live announcements ticker, and get personalised event
  recommendations based on what they've searched for.

"Service Request Status" remains disabled on the main menu until Part 3.

## Project structure

```
MunicipalServicesApp.sln
MunicipalServicesApp/
  MunicipalServicesApp.csproj
  Program.cs                              Application entry point
  Models/
    Issue.cs                              Represents one reported issue
    Event.cs                              Represents one local event/announcement
  Data/
    IssueRepository.cs                    Stores issues in a List<Issue>
    EventRepository.cs                    Seeds/organises events (see below)
    PriorityQueue.cs                      Custom generic min-heap priority queue
    RecommendationEngine.cs               Search-history-based event recommendations
  Forms/
    MainMenuForm.cs / .Designer.cs        Startup menu (3 options)
    ReportIssueForm.cs / .Designer.cs     Report Issues screen (Part 1)
    LocalEventsForm.cs / .Designer.cs     Local Events and Announcements screen (Part 2)
```

## How to compile and run

### Option A - Visual Studio (recommended)

1. Install **Visual Studio 2022** (Community edition is free) with the
   **.NET desktop development** workload.
2. Open `MunicipalServicesApp.sln`.
3. Press **F5** (or click **Start**) to build and run the application.

### Option B - command line

1. Install the [.NET SDK](https://dotnet.microsoft.com/) (Windows only,
   since this is a Windows Forms application).
2. From the `MunicipalServicesApp` folder (the one containing the
   `.csproj` file), run:
   ```
   dotnet build
   dotnet run
   ```

> Windows Forms applications only run on Windows. If you are working on
> macOS or Linux, use a Windows virtual machine or a lab PC to build and
> run the project.

## How to use Part 2 - Local Events and Announcements

1. From the **Main Menu**, click **Local Events and Announcements**
   (now enabled).
2. The screen opens showing:
   - A **ticker** near the top with the latest announcements.
   - A **"Next up"** line showing the single soonest upcoming event.
   - A scrollable list of **event cards** (click a card to see full
     details - this also adds it to "Recently Viewed").
3. Use the **search bar** to filter events:
   - **Keyword** - matches the event title, description or location.
   - **Category** - filter to a single category, or leave on
     "All Categories".
   - **From / To** - tick the checkbox next to either date to filter by
     a date range.
   - Click **Search** to apply the filters, or **Clear Filters** to
     reset and show every upcoming event again.
4. The right-hand panel shows:
   - **Recommended for You** - after you've searched a few times, this
     fills with events from the categories you've searched most often
     (double-click an entry to view it).
   - **Recently Viewed** - the last few events you opened, most recent
     first.
5. Click **Back to Main Menu** at any time to return to the start screen.

## Data structures used in Part 2 (technical requirement mapping)

- **Stacks, Queues, Priority Queues** - `EventRepository` keeps a
  `Queue<Event>` of newly published announcements (drained to build the
  ticker), a `Stack<Event>` of recently viewed events (LIFO, powers the
  "Recently Viewed" panel), and a hand-rolled `PriorityQueue<TElement,
  TPriority>` binary heap (`.NET Framework 4.8` has no built-in
  priority queue type) used to find the single soonest upcoming event
  and to rank recommended categories by search frequency.
- **Hash Tables, Dictionaries, Sorted Dictionaries** - events are
  indexed by category in a `Dictionary<string, List<Event>>` (hash
  table lookup) and by date in a `SortedDictionary<DateTime,
  List<Event>>`, which keeps events chronologically ordered for
  efficient date-based retrieval as required by the brief.
- **Sets** - `HashSet<string>` holds the unique event categories used
  to populate the category filter dropdown, and `HashSet<DateTime>`
  tracks the unique event dates.
- **Recommendation feature** - `RecommendationEngine` logs a
  `Dictionary<string, int>` of how often each category is searched,
  ranks those categories with the priority queue, and suggests
  upcoming events from the resident's most-searched categories that
  they haven't already seen in their current results.

## Notes for the marker

- Sample/seed event data (15 events across 7 categories, dated over the
  next ~5 weeks from whenever the app is run) is created in
  `EventRepository.Seed()` so the feature is demonstrable without a
  database.
- The recommendation engine starts empty ("Search for events to get
  personalised recommendations.") and builds up recommendations as
  searches are performed, to make the search-driven behaviour visible
  when demonstrating the app.