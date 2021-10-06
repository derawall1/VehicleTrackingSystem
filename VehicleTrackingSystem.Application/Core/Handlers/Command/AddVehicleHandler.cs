using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Responses.Command;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Core.Handlers.Command
{
    public class AddVehicleHandler : IRequestHandler<AddVehicleCommand, AddVehicleResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IContextRepository _httpContextRepository;


        public AddVehicleHandler(IVehicleRepository vehicleRepository, IContextRepository httpContextRepository)
        {
            _vehicleRepository = vehicleRepository;
            _httpContextRepository = httpContextRepository;
        }
        public async Task<AddVehicleResponse> Handle(AddVehicleCommand command, CancellationToken cancellationToken)
        {
            var vehicle = command.Adapt<Vehicle>();
            vehicle.UserId = _httpContextRepository.GetUserId();

            var result = await _vehicleRepository.InsertVehicle(vehicle);
            return result.Adapt<AddVehicleResponse>();
        }
    }

}
