using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MunicipalServicesApp.Data;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Forms
{
	/// <summary>
	/// Local Events and Announcements screen (Part 2 of the PoE). Lets a
	/// resident browse, search and filter municipal events, and shows
	/// personalised recommendations driven by their search history.
	/// </summary>
	public partial class LocalEventsForm : Form
	{
		private readonly RecommendationEngine _recommendationEngine = new RecommendationEngine();
		private System.Collections.Generic.List<Event> _recommendedEvents = new System.Collections.Generic.List<Event>();

		public LocalEventsForm()
		{
			InitializeComponent();
			SetupFilterControls();
			LoadTicker();
			LoadNextUp();
			ShowAllEvents();
			RefreshRecentlyViewed();
			RefreshRecommended(EventRepository.GetAllEventsChronological());
		}

		private void SetupFilterControls()
		{
			cmbCategoryFilter.Items.Add("All Categories");
			foreach (var category in EventRepository.Categories.OrderBy(c => c))
			{
				cmbCategoryFilter.Items.Add(category);
			}
			cmbCategoryFilter.SelectedIndex = 0;

			dtpFrom.Value = DateTime.Today;
			dtpTo.Value = DateTime.Today.AddMonths(1);
		}

		private void LoadTicker()
		{
			var latest = EventRepository.DrainAnnouncementFeed(3);
			lblTicker.Text = latest.Count == 0
				? "No announcements yet."
				: "\uD83D\uDCE2 Latest announcements: " + string.Join("   |   ", latest.Select(e => e.Title));
		}

		private void LoadNextUp()
		{
			var next = EventRepository.GetNextUpcomingEvent();
			lblNextUp.Text = next == null
				? "No upcoming events scheduled."
				: $"Next up: {next.Title} - {next.Date:ddd, dd MMM yyyy} at {next.Location}";
		}

		private void ShowAllEvents()
		{
			RenderResults(EventRepository.GetAllEventsChronological());
		}

		/// <summary>Rebuilds the scrollable list of event cards for the given results.</summary>
		private void RenderResults(System.Collections.Generic.List<Event> events)
		{
			flpEvents.SuspendLayout();
			flpEvents.Controls.Clear();

			if (events.Count == 0)
			{
				var emptyLabel = new Label
				{
					Text = "No events match your search. Try different filters.",
					Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
					ForeColor = Color.DimGray,
					AutoSize = false,
					Width = 600,
					Height = 40,
					Margin = new Padding(10)
				};
				flpEvents.Controls.Add(emptyLabel);
			}
			else
			{
				foreach (var ev in events)
				{
					flpEvents.Controls.Add(BuildEventCard(ev));
				}
			}

			flpEvents.ResumeLayout();
			lblResultCount.Text = $"Showing {events.Count} event{(events.Count == 1 ? "" : "s")}";
		}

		/// <summary>Builds a single "card" panel for an event, wired so clicking anywhere on it opens the details.</summary>
		private Panel BuildEventCard(Event ev)
		{
			var card = new Panel
			{
				Width = 610,
				Height = 92,
				Margin = new Padding(6),
				BorderStyle = BorderStyle.FixedSingle,
				BackColor = Color.White,
				Cursor = Cursors.Hand,
				Tag = ev
			};

			var tag = new Label
			{
				Text = ev.Category,
				Font = new Font("Segoe UI", 8F, FontStyle.Bold),
				ForeColor = Color.White,
				BackColor = Color.FromArgb(0, 82, 120),
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleCenter,
				Location = new Point(10, 10),
				Size = new Size(110, 20)
			};

			var title = new Label
			{
				Text = ev.Title,
				Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
				ForeColor = Color.FromArgb(30, 30, 30),
				AutoSize = false,
				Location = new Point(10, 34),
				Size = new Size(430, 22)
			};

			var meta = new Label
			{
				Text = $"{ev.Date:ddd, dd MMM yyyy}    \u2022    {ev.Location}",
				Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
				ForeColor = Color.DimGray,
				AutoSize = false,
				Location = new Point(10, 58),
				Size = new Size(430, 18)
			};

			var dateBadge = new Label
			{
				Text = ev.Date.ToString("dd MMM"),
				Font = new Font("Segoe UI", 10F, FontStyle.Bold),
				ForeColor = Color.FromArgb(0, 82, 120),
				TextAlign = ContentAlignment.MiddleCenter,
				Location = new Point(500, 10),
				Size = new Size(100, 70),
				BorderStyle = BorderStyle.FixedSingle
			};

			card.Controls.Add(tag);
			card.Controls.Add(title);
			card.Controls.Add(meta);
			card.Controls.Add(dateBadge);

			// Wire the click on the card itself and every child label so the
			// whole card is clickable, not just the empty background.
			EventHandler openDetails = (s, e) => ShowEventDetails(ev);
			card.Click += openDetails;
			foreach (Control child in card.Controls)
			{
				child.Cursor = Cursors.Hand;
				child.Click += openDetails;
			}

			return card;
		}

		/// <summary>
		/// Shows full event details, pushes the event onto the "recently
		/// viewed" Stack, and refreshes the side panel.
		/// </summary>
		private void ShowEventDetails(Event ev)
		{
			EventRepository.MarkViewed(ev);
			RefreshRecentlyViewed();

			MessageBox.Show(
				$"{ev.Title}\n\nCategory: {ev.Category}\nDate: {ev.Date:dddd, dd MMMM yyyy}\nLocation: {ev.Location}\n\n{ev.Description}",
				"Event Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void RefreshRecentlyViewed()
		{
			var recent = EventRepository.GetRecentlyViewed(8);
			lstRecentlyViewed.Items.Clear();
			if (recent.Count == 0)
			{
				lstRecentlyViewed.Items.Add("No events viewed yet.");
			}
			else
			{
				foreach (var ev in recent)
				{
					lstRecentlyViewed.Items.Add($"{ev.Title} - {ev.Date:dd MMM}");
				}
			}
		}

		/// <summary>Refreshes the "Recommended for You" list based on search history so far.</summary>
		private void RefreshRecommended(System.Collections.Generic.List<Event> currentResults)
		{
			lstRecommended.Items.Clear();

			if (!_recommendationEngine.HasSearchHistory)
			{
				_recommendedEvents = new System.Collections.Generic.List<Event>();
				lstRecommended.Items.Add("Search for events to get personalised recommendations.");
				return;
			}

			_recommendedEvents = _recommendationEngine.GetRecommendations(currentResults, 5);

			if (_recommendedEvents.Count == 0)
			{
				lstRecommended.Items.Add("No further recommendations right now.");
			}
			else
			{
				foreach (var ev in _recommendedEvents)
				{
					lstRecommended.Items.Add($"{ev.Title} - {ev.Date:dd MMM} ({ev.Category})");
				}
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			string keyword = txtKeyword.Text.Trim();
			string category = cmbCategoryFilter.SelectedItem?.ToString();
			DateTime? from = chkFrom.Checked ? dtpFrom.Value.Date : (DateTime?)null;
			DateTime? to = chkTo.Checked ? dtpTo.Value.Date : (DateTime?)null;

			var results = EventRepository.Search(keyword, category, from, to);
			RenderResults(results);

			_recommendationEngine.RecordSearch(keyword, category);
			RefreshRecommended(results);
		}

		private void btnClearSearch_Click(object sender, EventArgs e)
		{
			txtKeyword.Clear();
			cmbCategoryFilter.SelectedIndex = 0;
			chkFrom.Checked = false;
			chkTo.Checked = false;
			dtpFrom.Value = DateTime.Today;
			dtpTo.Value = DateTime.Today.AddMonths(1);
			ShowAllEvents();
		}

		private void chkFrom_CheckedChanged(object sender, EventArgs e)
		{
			dtpFrom.Enabled = chkFrom.Checked;
		}

		private void chkTo_CheckedChanged(object sender, EventArgs e)
		{
			dtpTo.Enabled = chkTo.Checked;
		}

		private void lstRecommended_DoubleClick(object sender, EventArgs e)
		{
			int index = lstRecommended.SelectedIndex;
			if (index < 0 || index >= _recommendedEvents.Count) return;

			ShowEventDetails(_recommendedEvents[index]);
		}

		private void btnBackToMenu_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}