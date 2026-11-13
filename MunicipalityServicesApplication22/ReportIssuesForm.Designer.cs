namespace MunicipalityServicesApplication22
{
    partial class ReportIssuesForm
    {
        private System.ComponentModel.IContainer components = null!;

        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblEngagement;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblEngagement = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // ReportIssuesForm
            // 
            this.Text = "Report Issues - Municipal Services";
            this.ClientSize = new System.Drawing.Size(620, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);

            // 
            // Title
            // 
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label();

            lblTitle.Text = "Report a Service Issue";
            lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                14F,
                System.Drawing.FontStyle.Bold);

            lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102);
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.AutoSize = true;

            this.Controls.Add(lblTitle);

            // 
            // Location Label
            // 
            System.Windows.Forms.Label lblLocation = new System.Windows.Forms.Label();

            lblLocation.Text = "Location of the Issue:";
            lblLocation.Location = new System.Drawing.Point(20, 60);
            lblLocation.AutoSize = true;

            this.Controls.Add(lblLocation);

            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(20, 85);
            this.txtLocation.Size = new System.Drawing.Size(560, 25);

            this.txtLocation.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.txtLocation.TextChanged +=
                new System.EventHandler(this.TxtLocation_TextChanged);

            this.Controls.Add(this.txtLocation);

            // 
            // Category Label
            // 
            System.Windows.Forms.Label lblCategory = new System.Windows.Forms.Label();

            lblCategory.Text = "Category:";
            lblCategory.Location = new System.Drawing.Point(20, 125);
            lblCategory.AutoSize = true;

            this.Controls.Add(lblCategory);

            // 
            // cmbCategory
            // 
            this.cmbCategory.Location = new System.Drawing.Point(20, 150);
            this.cmbCategory.Size = new System.Drawing.Size(560, 25);

            this.cmbCategory.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbCategory.Items.AddRange(
                new object[]
                {
                    "Sanitation",
                    "Roads",
                    "Utilities",
                    "Water",
                    "Electricity",
                    "Refuse Collection",
                    "Other"
                });

            this.cmbCategory.SelectedIndexChanged +=
                new System.EventHandler(this.CmbCategory_SelectedIndexChanged);

            this.Controls.Add(this.cmbCategory);

            // 
            // Description Label
            // 
            System.Windows.Forms.Label lblDescription =
                new System.Windows.Forms.Label();

            lblDescription.Text = "Detailed Description:";
            lblDescription.Location = new System.Drawing.Point(20, 190);
            lblDescription.AutoSize = true;

            this.Controls.Add(lblDescription);

            // 
            // rtbDescription
            // 
            this.rtbDescription.Location =
                new System.Drawing.Point(20, 215);

            this.rtbDescription.Size =
                new System.Drawing.Size(560, 120);

            this.rtbDescription.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.rtbDescription.TextChanged +=
                new System.EventHandler(this.RtbDescription_TextChanged);

            this.Controls.Add(this.rtbDescription);

            // 
            // btnAttach
            // 
            this.btnAttach.Text = "Attach Image / Document";

            this.btnAttach.Location =
                new System.Drawing.Point(20, 350);

            this.btnAttach.Size =
                new System.Drawing.Size(200, 35);

            this.btnAttach.BackColor =
                System.Drawing.Color.FromArgb(0, 120, 215);

            this.btnAttach.ForeColor =
                System.Drawing.Color.White;

            this.btnAttach.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnAttach.Click +=
                new System.EventHandler(this.BtnAttach_Click);

            this.Controls.Add(this.btnAttach);

            // 
            // lblAttachment
            // 
            this.lblAttachment.Text = "No file attached";

            this.lblAttachment.Location =
                new System.Drawing.Point(230, 358);

            this.lblAttachment.Size =
                new System.Drawing.Size(350, 25);

            this.lblAttachment.ForeColor =
                System.Drawing.Color.Gray;

            this.Controls.Add(this.lblAttachment);

            // 
            // Progress Label
            // 
            System.Windows.Forms.Label lblProgress =
                new System.Windows.Forms.Label();

            lblProgress.Text = "Report Progress:";
            lblProgress.Location =
                new System.Drawing.Point(20, 400);

            lblProgress.AutoSize = true;

            this.Controls.Add(lblProgress);

            // 
            // progressBar
            // 
            this.progressBar.Location =
                new System.Drawing.Point(20, 425);

            this.progressBar.Size =
                new System.Drawing.Size(560, 25);

            this.progressBar.Maximum = 100;
            this.progressBar.Value = 0;

            this.Controls.Add(this.progressBar);

            // 
            // lblEngagement
            // 
            this.lblEngagement.Location =
                new System.Drawing.Point(20, 460);

            this.lblEngagement.Size =
                new System.Drawing.Size(560, 30);

            this.lblEngagement.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Italic);

            this.lblEngagement.ForeColor =
                System.Drawing.Color.FromArgb(0, 100, 0);

            this.Controls.Add(this.lblEngagement);

            // 
            // btnSubmit
            // 
            this.btnSubmit.Text = "Submit Report";

            this.btnSubmit.Location =
                new System.Drawing.Point(20, 510);

            this.btnSubmit.Size =
                new System.Drawing.Size(200, 45);

            this.btnSubmit.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.btnSubmit.BackColor =
                System.Drawing.Color.FromArgb(0, 153, 51);

            this.btnSubmit.ForeColor =
                System.Drawing.Color.White;

            this.btnSubmit.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnSubmit.Click +=
                new System.EventHandler(this.BtnSubmit_Click);

            this.Controls.Add(this.btnSubmit);

            // 
            // btnBack
            // 
            this.btnBack.Text = "Back to Main Menu";

            this.btnBack.Location =
                new System.Drawing.Point(380, 510);

            this.btnBack.Size =
                new System.Drawing.Size(200, 45);

            this.btnBack.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.btnBack.BackColor =
                System.Drawing.Color.FromArgb(100, 100, 100);

            this.btnBack.ForeColor =
                System.Drawing.Color.White;

            this.btnBack.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnBack.Click +=
                new System.EventHandler(this.BtnBack_Click);

            this.Controls.Add(this.btnBack);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}