
namespace MunicipalityServicesApplication22
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnLocalEvents;
        private System.Windows.Forms.Button btnServiceStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnReportIssues = new System.Windows.Forms.Button();
            this.btnLocalEvents = new System.Windows.Forms.Button();
            this.btnServiceStatus = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Main form
            this.Text = "Municipal Services Application - Main Menu";
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);

            // Title
            this.lblTitle.Text = "Municipal Services Application";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(80, 30);

            // Subtitle
            this.lblSubtitle.Text =
                "South African Municipality - Citizen Engagement";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(90, 70);

            // Report Issues button
            this.btnReportIssues.Text = "1. Report Issues";
            this.btnReportIssues.Size = new System.Drawing.Size(300, 50);
            this.btnReportIssues.Location = new System.Drawing.Point(100, 130);
            this.btnReportIssues.Font = new System.Drawing.Font("Segoe UI", 11F,
                System.Drawing.FontStyle.Bold);
            this.btnReportIssues.BackColor =
                System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnReportIssues.ForeColor = System.Drawing.Color.White;
            this.btnReportIssues.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnReportIssues.Click +=
                new System.EventHandler(this.BtnReportIssues_Click);

            // Local Events button
            this.btnLocalEvents.Text = "2. Local Events and Announcements";
            this.btnLocalEvents.Size = new System.Drawing.Size(300, 50);
            this.btnLocalEvents.Location = new System.Drawing.Point(100, 200);
            this.btnLocalEvents.Font = new System.Drawing.Font("Segoe UI", 11F,
                System.Drawing.FontStyle.Bold);
            this.btnLocalEvents.BackColor =
                System.Drawing.Color.FromArgb(0, 153, 76);
            this.btnLocalEvents.ForeColor = System.Drawing.Color.White;
            this.btnLocalEvents.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalEvents.Click +=
                new System.EventHandler(this.BtnLocalEvents_Click);

            // Service Request Status button
            this.btnServiceStatus.Text = "3. Service Request Status";
            this.btnServiceStatus.Size = new System.Drawing.Size(300, 50);
            this.btnServiceStatus.Location = new System.Drawing.Point(100, 270);
            this.btnServiceStatus.Font = new System.Drawing.Font(
                "Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnServiceStatus.Enabled = true;
            this.btnServiceStatus.BackColor =
                System.Drawing.Color.FromArgb(204, 102, 0);
            this.btnServiceStatus.ForeColor = System.Drawing.Color.White;
            this.btnServiceStatus.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceStatus.Click +=
                new System.EventHandler(this.BtnServiceStatus_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.btnReportIssues);
            this.Controls.Add(this.btnLocalEvents);
            this.Controls.Add(this.btnServiceStatus);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
