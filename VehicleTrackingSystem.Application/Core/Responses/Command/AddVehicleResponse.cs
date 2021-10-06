using System.Collections.Generic;

namespace VehicleTrackingSystem.Application.Core.Responses.Command
{
    public class AddVehicleResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DeviceId { get; set; }
        public IDictionary<string, string> ExtendedData { get; set; }
    }
}
