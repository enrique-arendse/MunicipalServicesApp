using System;
using System.Windows.Forms;
using System.Runtime.InteropServices; 
using MunicipalServicesApp.Data;

namespace MunicipalServicesApp.Forms
{
    /// <summary>
    /// Lets a resident report a municipal issue: location, category,
    /// description, and an optional attachment. Implements the chosen
    /// user engagement strategy - real-time gamified feedback - via a
    /// ProgressBar and an encouraging message label that update live as
    /// the resident completes the form.
    /// </summary>
    public partial class ReportIssueForm : Form
    {
       
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        private const string LocationPlaceholder = "e.g. Corner of Main Rd and 5th Ave, Ward 12";
        // ---------------------------------------------------------

        private string _attachedFilePath = string.Empty;

        public ReportIssueForm()
        {
            InitializeComponent();

            
            SendMessage(txtLocation.Handle, EM_SETCUEBANNER, 0, LocationPlaceholder);
        }

        /// <summary>
        /// Opens a file dialog so the resident can attach an image or
        /// document as evidence of the reported issue.
        /// </summary>
        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Attach an image or document";
                dialog.Filter = "Supported files (*.jpg;*.jpeg;*.png;*.pdf;*.docx)|*.jpg;*.jpeg;*.png;*.pdf;*.docx|All files (*.*)|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _attachedFilePath = dialog.FileName;
                    lblAttachment.Text = System.IO.Path.GetFileName(_attachedFilePath);
                    lblAttachment.ForeColor = System.Drawing.Color.FromArgb(0, 120, 90);
                }
            }

            UpdateEngagementFeedback();
        }

        /// <summary>
        /// Fires whenever a tracked field changes, keeping the engagement
        /// ProgressBar and message in sync with the resident's progress.
        /// </summary>
        private void OnEngagementFieldChanged(object sender, EventArgs e)
        {
            UpdateEngagementFeedback();
        }

        /// <summary>
        /// Core of the gamified engagement feature: scores how complete
        /// the report is out of four fields (location, category,
        /// description, attachment) and shows an encouraging message that
        /// changes as the resident progresses, positively reinforcing
        /// participation as motivated by the research in Task 1.
        /// </summary>
        private void UpdateEngagementFeedback()
        {
            int completed = 0;
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) completed++;
            if (cmbCategory.SelectedIndex != -1) completed++;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) completed++;
            if (!string.IsNullOrWhiteSpace(_attachedFilePath)) completed++;

            int percentage = (completed * 100) / 4;
            progressEngagement.Value = Math.Min(percentage, progressEngagement.Maximum);

            switch (completed)
            {
                case 0:
                    lblEngagement.Text = "Let's get started - fill in the details of the issue below.";
                    break;
                case 1:
                    lblEngagement.Text = "Good start! Keep going - every detail helps your municipality respond faster.";
                    break;
                case 2:
                    lblEngagement.Text = "Halfway there! Your report is helping make your community better.";
                    break;
                case 3:
                    lblEngagement.Text = "Almost done! Add a photo or document to strengthen your report (optional).";
                    break;
                case 4:
                    lblEngagement.Text = "Excellent! Your report is complete and ready to submit. Thank you!";
                    break;
            }
        }

        /// <summary>
        /// Validates the required fields and, if valid, stores the issue in
        /// the shared IssueRepository (a List&lt;Issue&gt;) and confirms
        /// submission to the user.
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Missing information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category for the issue.", "Missing information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please provide a description of the issue.", "Missing information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            var issue = IssueRepository.AddIssue(
                txtLocation.Text.Trim(),
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text.Trim(),
                _attachedFilePath);

            MessageBox.Show(
                $"Thank you! Your issue has been reported.\n\nReference number: {issue.ReferenceNumber}\n" +
                "You can use this reference to track the status of your request once that feature is released.",
                "Report submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
        }

        private void ClearForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            _attachedFilePath = string.Empty;
            lblAttachment.Text = "No file attached";
            lblAttachment.ForeColor = System.Drawing.Color.DimGray;

           
            SendMessage(txtLocation.Handle, EM_SETCUEBANNER, 0, LocationPlaceholder);

            UpdateEngagementFeedback();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
