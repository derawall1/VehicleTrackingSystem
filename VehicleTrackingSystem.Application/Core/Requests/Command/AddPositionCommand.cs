using MediatR;
using VehicleTrackingSystem.Application.Core.Responses.Command;

namespace VehicleTrackingSystem.Application.Core.Requests.Command
{
    public class AddPositionCommand : IRequest<AddPositionResponse>
    {
        public string DeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
