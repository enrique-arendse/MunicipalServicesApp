using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
	/// <summary>
	/// The application's main menu. Presents the three top-level tasks
	/// required by the PoE. "Report Issues" (Part 1) and "Local Events and
	/// Announcements" (Part 2) are implemented; "Service Request Status"
	/// remains disabled until Part 3.
	/// </summary>
	public partial class MainMenuForm : Form
	{
		public MainMenuForm()
		{
			InitializeComponent();
		}

		private void btnReportIssues_Click(object sender, System.EventArgs e)
		{
			using (var reportForm = new ReportIssueForm())
			{
				this.Hide();
				reportForm.ShowDialog();
				this.Show();
			}
		}

		private void btnLocalEvents_Click(object sender, System.EventArgs e)
		{
			using (var eventsForm = new LocalEventsForm())
			{
				this.Hide();
				eventsForm.ShowDialog();
				this.Show();
			}
		}
	}
}