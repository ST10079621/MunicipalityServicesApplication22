using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityServicesApplication22
{
    public class Event
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Date.ToString("dd MMM yyyy") + " | " +
                Title + " | " + Category + " | " + Location +
                " | " + Description;
        }
    }
}
