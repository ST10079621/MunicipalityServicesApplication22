
using System;
using System.Windows.Forms;

namespace MunicipalityServicesApplication22
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void BtnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportForm = new ReportIssuesForm();
            reportForm.Show();
            this.Hide();
        }

        private void BtnLocalEvents_Click(object sender, EventArgs e)
        {
            LocalEventsForm eventsForm = new LocalEventsForm(this);
            eventsForm.Show();
            this.Hide();
        }

        private void BtnServiceStatus_Click(object sender, EventArgs e)
        {
            ServiceRequestStatusForm statusForm =
                new ServiceRequestStatusForm(this);

            statusForm.Show();
            this.Hide();
        }
    }
}
