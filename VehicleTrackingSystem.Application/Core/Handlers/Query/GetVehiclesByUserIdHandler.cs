using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Query;
using VehicleTrackingSystem.Application.Core.Responses.Query;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Core.Handlers.Query
{
    public class GetVehiclesByUserIdHandler : IRequestHandler<GetVehiclesByUserIdQuery, List<GetVehiclesByUserIdResponse>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IContextRepository _httpContextRepository;

        public GetVehiclesByUserIdHandler(IVehicleRepository vehicleRepository, IContextRepository httpContextRepository)
        {
            _vehicleRepository = vehicleRepository;
            _httpContextRepository = httpContextRepository;
        }
        public async Task<List<GetVehiclesByUserIdResponse>> Handle(GetVehiclesByUserIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _vehicleRepository.GetVehiclesByUserId(_httpContextRepository.GetUserId());
            var response = result.Select(e => new GetVehiclesByUserIdResponse
            {
                VehicleId = e.Id,
                Name = e.Name,
                DeviceId = e.DeviceId,
                ExtendedData =e.ExtendedData

            }).ToList();
            
            return response;
        }
    }
}
