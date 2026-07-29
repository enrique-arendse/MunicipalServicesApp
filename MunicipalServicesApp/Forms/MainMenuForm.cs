using System.Windows.Forms;

namespace MunicipalServicesApp.Forms
{
    /// <summary>
    /// The application's main menu. Presents the three top-level tasks
    /// required by the PoE. Only "Report Issues" is implemented in Part 1;
    /// the other two options are visible but disabled, per the spec.
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
    }
}
