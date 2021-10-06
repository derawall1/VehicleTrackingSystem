using MediatR;
using VehicleTrackingSystem.Application.Core.Responses.Query;

namespace VehicleTrackingSystem.Application.Core.Requests.Query
{
    public class GetCurrentPositionQuery : IRequest<GetCurrentPositionResponse>
    {
        public long VehicleId { get; set; }

    } 
}
