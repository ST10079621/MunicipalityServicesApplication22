
namespace MunicipalityServicesApplication22
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblRec;
        private System.Windows.Forms.Label lblInfo;

        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnRecommend;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.ListBox lstRecommendations;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblRec = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();

            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnRecommend = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            this.lstEvents = new System.Windows.Forms.ListBox();
            this.lstRecommendations = new System.Windows.Forms.ListBox();

            this.SuspendLayout();

            // Form
            this.Text = "Local Events and Announcements";
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);

            // Title
            this.lblTitle.Text = "Local Events & Announcements";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(0, 51, 102);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.AutoSize = true;

            // Category label
            this.lblSearch.Text = "Search by Category:";
            this.lblSearch.Location = new System.Drawing.Point(20, 60);
            this.lblSearch.AutoSize = true;

            // Category dropdown
            this.cmbCategory.Location = new System.Drawing.Point(150, 57);
            this.cmbCategory.Size = new System.Drawing.Size(180, 25);
            this.cmbCategory.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Date label
            this.lblDate.Text = "Date:";
            this.lblDate.Location = new System.Drawing.Point(350, 60);
            this.lblDate.AutoSize = true;

            // Date picker
            this.dtpDate.Location = new System.Drawing.Point(400, 57);
            this.dtpDate.Size = new System.Drawing.Size(150, 25);
            this.dtpDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;

            // Search button
            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new System.Drawing.Point(570, 55);
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.BackColor =
                System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Click +=
                new System.EventHandler(this.BtnSearch_Click);

            // Show All button
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.Location = new System.Drawing.Point(680, 55);
            this.btnShowAll.Size = new System.Drawing.Size(100, 30);
            this.btnShowAll.Click +=
                new System.EventHandler(this.BtnShowAll_Click);

            // Events heading
            this.lblEvents.Text = "Upcoming Events:";
            this.lblEvents.Location = new System.Drawing.Point(20, 100);
            this.lblEvents.Font = new System.Drawing.Font("Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblEvents.AutoSize = true;

            // Events list
            this.lstEvents.Location = new System.Drawing.Point(20, 125);
            this.lstEvents.Size = new System.Drawing.Size(840, 250);
            this.lstEvents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstEvents.HorizontalScrollbar = true;

            // Recommendations heading
            this.lblRec.Text =
                "Recommended Events (based on your searches):";
            this.lblRec.Location = new System.Drawing.Point(20, 390);
            this.lblRec.Font = new System.Drawing.Font("Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblRec.AutoSize = true;

            // Recommendations list
            this.lstRecommendations.Location =
                new System.Drawing.Point(20, 415);
            this.lstRecommendations.Size =
                new System.Drawing.Size(840, 100);
            this.lstRecommendations.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.lstRecommendations.HorizontalScrollbar = true;

            // Recommendation button
            this.btnRecommend.Text = "Get Recommendations";
            this.btnRecommend.Location = new System.Drawing.Point(20, 530);
            this.btnRecommend.Size = new System.Drawing.Size(180, 35);
            this.btnRecommend.BackColor =
                System.Drawing.Color.FromArgb(0, 153, 51);
            this.btnRecommend.ForeColor = System.Drawing.Color.White;
            this.btnRecommend.Click +=
                new System.EventHandler(this.BtnRecommend_Click);

            // Back button
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.Location = new System.Drawing.Point(700, 530);
            this.btnBack.Size = new System.Drawing.Size(160, 35);
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Click +=
                new System.EventHandler(this.BtnBack_Click);

            // Information label
            this.lblInfo.Location = new System.Drawing.Point(220, 535);
            this.lblInfo.Size = new System.Drawing.Size(450, 30);
            this.lblInfo.ForeColor = System.Drawing.Color.DarkGreen;

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.lblEvents);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.lblRec);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.btnRecommend);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblInfo);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
