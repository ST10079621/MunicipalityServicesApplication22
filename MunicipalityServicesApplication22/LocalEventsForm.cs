
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalityServicesApplication22
{
    public partial class LocalEventsForm : Form
    {
        private readonly MainMenuForm mainMenu;

        private readonly SortedDictionary<DateTime, List<Event>> eventsByDate =
            new SortedDictionary<DateTime, List<Event>>();

        private readonly SortedSet<Event> priorityQueue =
            new SortedSet<Event>(Comparer<Event>.Create((a, b) =>
            {
                int result = a.Date.CompareTo(b.Date);

                if (result == 0)
                    result = string.Compare(a.Title, b.Title,
                        StringComparison.Ordinal);

                return result;
            }));

        private readonly HashSet<string> uniqueCategories =
            new HashSet<string>();

        private readonly Dictionary<string, int> searchHistory =
            new Dictionary<string, int>();

        private bool returningToMenu;

        public LocalEventsForm() : this(null)
        {
        }

        public LocalEventsForm(MainMenuForm menu)
        {
            mainMenu = menu;
            InitializeComponent();
            LoadSampleEvents();
            RefreshEventList();
        }

        private void LoadSampleEvents()
        {
            AddEvent("Community Clean-up Day", "Community", 3,
                "Central Park", "Join us to clean the park");

            AddEvent("Water Conservation Workshop", "Education", 5,
                "Municipal Hall", "Learn how to save water");

            AddEvent("Road Safety Awareness", "Safety", 7,
                "Town Square", "Road safety for all residents");

            AddEvent("Free Health Screening", "Health", 2,
                "Clinic Hall", "Blood pressure and diabetes screening");

            AddEvent("Youth Sports Tournament", "Sports", 10,
                "Sports Ground", "Soccer and netball tournament");

            AddEvent("Load Shedding Information Session", "Utilities", 4,
                "Community Centre", "How to prepare for load shedding");

            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            foreach (string category in uniqueCategories.OrderBy(c => c))
                cmbCategory.Items.Add(category);

            cmbCategory.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
        }

        private void AddEvent(string title, string category, int days,
            string location, string description)
        {
            Event ev = new Event
            {
                Title = title,
                Category = category,
                Date = DateTime.Today.AddDays(days),
                Location = location,
                Description = description
            };

            DateTime date = ev.Date.Date;

            if (!eventsByDate.ContainsKey(date))
                eventsByDate[date] = new List<Event>();

            eventsByDate[date].Add(ev);
            priorityQueue.Add(ev);
            uniqueCategories.Add(category);
        }

        private void RefreshEventList()
        {
            lstEvents.Items.Clear();

            foreach (Event ev in priorityQueue)
                lstEvents.Items.Add(ev.ToString());

            lblInfo.Text = "Total events: " + priorityQueue.Count +
                " | Unique categories: " + uniqueCategories.Count;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            lstEvents.Items.Clear();

            string category = cmbCategory.SelectedItem == null
                ? "All Categories"
                : cmbCategory.SelectedItem.ToString();

            DateTime selectedDate = dtpDate.Value.Date;

            if (category != "All Categories")
            {
                if (!searchHistory.ContainsKey(category))
                    searchHistory[category] = 0;

                searchHistory[category]++;
            }

            List<Event> results = priorityQueue.Where(ev =>
                (category == "All Categories" || ev.Category == category) &&
                ev.Date.Date >= selectedDate).ToList();

            foreach (Event ev in results)
                lstEvents.Items.Add(ev.ToString());

            lblInfo.Text = "Found " + results.Count + " event(s)";
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            RefreshEventList();
        }

        private void BtnRecommend_Click(object sender, EventArgs e)
        {
            lstRecommendations.Items.Clear();

            if (searchHistory.Count == 0)
            {
                lstRecommendations.Items.Add(
                    "No search history yet. Please search for events first.");
                return;
            }

            string topCategory = searchHistory
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .First().Key;

            List<Event> recommended = priorityQueue
                .Where(ev => ev.Category == topCategory)
                .Take(5)
                .ToList();

            lstRecommendations.Items.Add(
                "Based on your interest in '" + topCategory + "':");

            foreach (Event ev in recommended)
                lstRecommendations.Items.Add("- " + ev.ToString());

            if (recommended.Count == 0)
                lstRecommendations.Items.Add("No upcoming events found.");
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            returningToMenu = true;

            if (mainMenu != null && !mainMenu.IsDisposed)
            {
                mainMenu.Show();
                mainMenu.Activate();
            }
            else
            {
                new MainMenuForm().Show();
            }

            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (!e.Cancel && !returningToMenu &&
                e.CloseReason == CloseReason.UserClosing)
            {
                if (mainMenu != null && !mainMenu.IsDisposed)
                {
                    mainMenu.Show();
                    mainMenu.Activate();
                }
                else
                {
                    new MainMenuForm().Show();
                }
            }
        }
    }

   
}
