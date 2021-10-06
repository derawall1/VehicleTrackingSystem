using System.Collections.Generic;

namespace VehicleTrackingSystem.Application.Core.Responses.Query
{
    public class GetVehiclesByUserIdResponse
    {
        public long VehicleId { get; set; }
        public string Name { get; set; }
        public string DeviceId { get; set; }
        public IDictionary<string, string> ExtendedData { get; set; }
    }
}
