using FluentValidation;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Validators
{
    public class AddVehicleCommandValidator : AbstractValidator<AddVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public AddVehicleCommandValidator(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
            bool firstPhasePassed = true;

            RuleFor(e => e.Name)
               .NotEmpty()
               .Length(0, 100)
               .OnAnyFailure(x => { firstPhasePassed = false; });

            RuleFor(e => e.DeviceId).NotEmpty()
              .OnAnyFailure(x => { firstPhasePassed = false; });

            When(x => firstPhasePassed, () =>
            {

                RuleFor(x => x)
                .NotEmpty()
               .MustAsync((x, cancellation) => IsDeviceExists(x)).WithMessage("Device Id Must be unique.");
            });
        }

        protected async Task<bool> IsDeviceExists(AddVehicleCommand command)
        {

            var device = await _vehicleRepository.GetVehicleByDeviceId(command.DeviceId);
            if (device != null)
            {
                return false;
            }

            return true;


        }
    }
}
