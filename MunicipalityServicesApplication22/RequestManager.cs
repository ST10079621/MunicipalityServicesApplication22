using System.Collections.Generic;

namespace MunicipalityServicesApplication22
{
    // Shared in-memory store so Report Issues can feed Service Request Status
    public static class RequestManager
    {
        public static List<ServiceRequest> AllRequests { get; } = new List<ServiceRequest>();
    }
}