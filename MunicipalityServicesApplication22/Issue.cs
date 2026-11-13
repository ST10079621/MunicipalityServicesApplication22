using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityServicesApplication22
{
    public class Issue
    {
        public string Id { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AttachmentPath { get; set; } = string.Empty;
        public DateTime ReportedDate { get; set; }

        public Issue()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            ReportedDate = DateTime.Now;
        }
    }
}
