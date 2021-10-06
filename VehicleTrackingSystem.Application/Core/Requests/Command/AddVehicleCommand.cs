using MediatR;
using System.Collections.Generic;
using VehicleTrackingSystem.Application.Core.Responses.Command;

namespace VehicleTrackingSystem.Application.Core.Requests.Command
{
    public class AddVehicleCommand : IRequest<AddVehicleResponse>
    {
        public string Name { get; set; }
        public string DeviceId { get; set; }
        public IDictionary<string, string> ExtendedData { get; set; }
    } 
}
