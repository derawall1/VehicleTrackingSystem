using MediatR;
using System.Collections.Generic;
using VehicleTrackingSystem.Application.Core.Responses.Query;

namespace VehicleTrackingSystem.Application.Core.Requests.Query
{
    public class GetVehiclesByUserIdQuery : IRequest<List<GetVehiclesByUserIdResponse>>
    {

    }
}
