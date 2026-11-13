using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MunicipalityServicesApplication22
{
    public partial class ReportIssuesForm : Form
    {
        // Data
        private readonly List<Issue> reportedIssues = new List<Issue>();
        private string selectedFilePath = string.Empty;

        // Used to prevent the Main Menu from opening twice
        private bool returningToMainMenu = false;

        public ReportIssuesForm()
        {
            InitializeComponent();
            UpdateProgressAndMessage();
        }

        private void BtnAttach_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Image or Document";
                ofd.Filter =
                    "Images and Documents|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.pdf;*.doc;*.docx;*.txt|" +
                    "All files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;

                    lblAttachment.Text = Path.GetFileName(selectedFilePath);
                    lblAttachment.ForeColor = Color.Black;

                    UpdateProgressAndMessage();
                }
            }
        }

        private void TxtLocation_TextChanged(object? sender, EventArgs e)
        {
            UpdateProgressAndMessage();
        }

        private void CmbCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateProgressAndMessage();
        }

        private void RtbDescription_TextChanged(object? sender, EventArgs e)
        {
            UpdateProgressAndMessage();
        }

        private void UpdateProgressAndMessage()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                progress += 25;

            if (cmbCategory.SelectedIndex >= 0)
                progress += 25;

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
                progress += 25;

            if (!string.IsNullOrEmpty(selectedFilePath))
                progress += 25;

            progressBar.Value = progress;

            if (progress == 0)
            {
                lblEngagement.Text =
                    "Start by telling us the location of the problem.";
            }
            else if (progress == 25)
            {
                lblEngagement.Text =
                    "Good start! Please select a category.";
            }
            else if (progress == 50)
            {
                lblEngagement.Text =
                    "Great! Now describe the issue in detail.";
            }
            else if (progress == 75)
            {
                lblEngagement.Text =
                    "Almost done! Attaching a photo helps a lot.";
            }
            else
            {
                lblEngagement.Text =
                    "Perfect! Click Submit to send your report and help your community.";
            }
        }

        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            // Validate location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLocation.Focus();
                return;
            }

            // Validate category
            if (cmbCategory.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please select a category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            // Validate description
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a description of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                rtbDescription.Focus();
                return;
            }

            // Get selected category safely
            string category = cmbCategory.SelectedItem?.ToString() ?? "Other";

            // Create the issue
            Issue newIssue = new Issue
            {
                Location = txtLocation.Text.Trim(),
                Category = category,
                Description = rtbDescription.Text.Trim(),
                AttachmentPath = selectedFilePath
            };

            // Add issue to the list
            reportedIssues.Add(newIssue);

            

            ServiceRequest req = new ServiceRequest
            {
                Id = newIssue.Id,               
                Location = newIssue.Location,
                Category = newIssue.Category,
                Description = newIssue.Description,
                Status = "Submitted",
                Priority = 2,
                SubmittedDate = DateTime.Now
            };
            RequestManager.AllRequests.Add(req);

            // Confirmation
            MessageBox.Show(
                $"Thank you for reporting the issue!\n\n" +
                $"Reference Number: {newIssue.Id}\n" +
                $"Category: {newIssue.Category}\n" +
                $"Location: {newIssue.Location}\n\n" +
                "Your report has been received. The municipality will investigate and update you.",
                "Report Submitted Successfully",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearForm();
        }

        private void ClearForm()
        {
            txtLocation.Clear();

            cmbCategory.SelectedIndex = -1;

            rtbDescription.Clear();

            selectedFilePath = string.Empty;

            lblAttachment.Text = "No file attached";
            lblAttachment.ForeColor = Color.Gray;

            progressBar.Value = 0;

            UpdateProgressAndMessage();

            txtLocation.Focus();
        }

        private void BtnBack_Click(object? sender, EventArgs e)
        {
            returningToMainMenu = true;

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();

            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Only open Main Menu when the user closes the form manually.
            // Do not open another Main Menu when BtnBack_Click already did it.
            if (e.CloseReason == CloseReason.UserClosing &&
                !returningToMainMenu)
            {
                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.Show();
            }
        }
    }
}
