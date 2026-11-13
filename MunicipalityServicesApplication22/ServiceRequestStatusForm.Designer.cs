
namespace MunicipalityServicesApplication22
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblGraph;
        private System.Windows.Forms.Label lblInfo;

        private System.Windows.Forms.TextBox txtSearchId;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnTraverse;
        private System.Windows.Forms.Button btnMST;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.ListBox lstRequests;
        private System.Windows.Forms.ListBox lstGraphOutput;

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
            this.lblGraph = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();

            this.txtSearchId = new System.Windows.Forms.TextBox();

            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnTraverse = new System.Windows.Forms.Button();
            this.btnMST = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            this.lstRequests = new System.Windows.Forms.ListBox();
            this.lstGraphOutput = new System.Windows.Forms.ListBox();

            this.SuspendLayout();

            // Form
            this.Text = "Service Request Status";
            this.ClientSize = new System.Drawing.Size(950, 620);
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor =
                System.Drawing.Color.FromArgb(245, 250, 255);

            // Title
            this.lblTitle.Text = "Service Request Status Tracker";
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(0, 51, 102);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.AutoSize = true;

            // Search label
            this.lblSearch.Text = "Track by Reference ID:";
            this.lblSearch.Location = new System.Drawing.Point(20, 60);
            this.lblSearch.AutoSize = true;

            // Reference ID input
            this.txtSearchId.Location =
                new System.Drawing.Point(180, 57);
            this.txtSearchId.Size =
                new System.Drawing.Size(150, 25);

            // Search button
            this.btnSearch.Text = "Search (BST)";
            this.btnSearch.Location =
                new System.Drawing.Point(350, 55);
            this.btnSearch.Size =
                new System.Drawing.Size(120, 30);
            this.btnSearch.BackColor =
                System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Click +=
                new System.EventHandler(this.BtnSearch_Click);

            // Show All button
            this.btnShowAll.Text = "Show All (Heap)";
            this.btnShowAll.Location =
                new System.Drawing.Point(480, 55);
            this.btnShowAll.Size =
                new System.Drawing.Size(130, 30);
            this.btnShowAll.Click +=
                new System.EventHandler(this.BtnShowAll_Click);

            // Requests list
            this.lstRequests.Location =
                new System.Drawing.Point(20, 100);
            this.lstRequests.Size =
                new System.Drawing.Size(890, 250);
            this.lstRequests.Font =
                new System.Drawing.Font("Consolas", 10F);
            this.lstRequests.HorizontalScrollbar = true;

            // Graph heading
            this.lblGraph.Text = "Graph / Traversal / MST Output:";
            this.lblGraph.Location =
                new System.Drawing.Point(20, 360);
            this.lblGraph.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGraph.AutoSize = true;

            // Graph output
            this.lstGraphOutput.Location =
                new System.Drawing.Point(20, 385);
            this.lstGraphOutput.Size =
                new System.Drawing.Size(890, 150);
            this.lstGraphOutput.Font =
                new System.Drawing.Font("Consolas", 9F);
            this.lstGraphOutput.HorizontalScrollbar = true;

            // BFS button
            this.btnTraverse.Text = "BFS Traversal";
            this.btnTraverse.Location =
                new System.Drawing.Point(20, 550);
            this.btnTraverse.Size =
                new System.Drawing.Size(140, 35);
            this.btnTraverse.BackColor =
                System.Drawing.Color.FromArgb(0, 153, 51);
            this.btnTraverse.ForeColor = System.Drawing.Color.White;
            this.btnTraverse.Click +=
                new System.EventHandler(this.BtnTraverse_Click);

            // MST button
            this.btnMST.Text = "Build MST";
            this.btnMST.Location =
                new System.Drawing.Point(180, 550);
            this.btnMST.Size =
                new System.Drawing.Size(140, 35);
            this.btnMST.BackColor =
                System.Drawing.Color.FromArgb(153, 0, 153);
            this.btnMST.ForeColor = System.Drawing.Color.White;
            this.btnMST.Click +=
                new System.EventHandler(this.BtnMST_Click);

            // Information label
            this.lblInfo.Location =
                new System.Drawing.Point(340, 555);
            this.lblInfo.Size =
                new System.Drawing.Size(400, 35);
            this.lblInfo.ForeColor = System.Drawing.Color.DarkGreen;

            // Back button
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.Location =
                new System.Drawing.Point(750, 550);
            this.btnBack.Size =
                new System.Drawing.Size(160, 35);
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Click +=
                new System.EventHandler(this.BtnBack_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchId);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.lstRequests);
            this.Controls.Add(this.lblGraph);
            this.Controls.Add(this.lstGraphOutput);
            this.Controls.Add(this.btnTraverse);
            this.Controls.Add(this.btnMST);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnBack);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
