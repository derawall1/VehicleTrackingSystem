using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Responses.Command;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Core.Handlers.Command
{
    public class AddPositionHandler : IRequestHandler<AddPositionCommand, AddPositionResponse>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public AddPositionHandler(IPositionRepository positionRepository, IVehicleRepository vehicleRepository)
        {
            _positionRepository = positionRepository;
            _vehicleRepository = vehicleRepository;
        }
        public async Task<AddPositionResponse> Handle(AddPositionCommand command, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetVehicleByDeviceId(command.DeviceId);

            var position = command.Adapt<Position>();
            position.VehicleId = vehicle.Id;
            var result = await _positionRepository.InsertPosition(position);
            return result.Adapt<AddPositionResponse>();
        }
    }

}
