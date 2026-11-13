using System;

namespace MunicipalityServicesApplication22
{
    public class ServiceRequest
    {
        public string Id { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Submitted"; // Submitted, In Progress, Resolved
        public int Priority { get; set; } = 2; // 1 = High, 2 = Medium, 3 = Low
        public DateTime SubmittedDate { get; set; } = DateTime.Now;

        public ServiceRequest()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }

        public override string ToString()
        {
            return $"[{Id}] {Category} | {Location} | Status: {Status} | Priority: {Priority} | {SubmittedDate:dd MMM yyyy}";
        }
    }
}