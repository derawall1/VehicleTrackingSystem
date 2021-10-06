using FluentValidation;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Validators
{
    public class AddPositionCommandValidator : AbstractValidator<AddPositionCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IContextRepository _contextRepository;

        public AddPositionCommandValidator(IVehicleRepository vehicleRepository, IContextRepository contextRepository)
        {
            _vehicleRepository = vehicleRepository;
            _contextRepository = contextRepository;
            bool firstPhasePassed = true;

            RuleFor(e => e.DeviceId)
               .NotEmpty()
               .OnAnyFailure(x => { firstPhasePassed = false; });
            RuleFor(e => e.Latitude)
               .NotEmpty()
               .OnAnyFailure(x => { firstPhasePassed = false; });
            RuleFor(e => e.Longitude).NotEmpty()
              .OnAnyFailure(x => { firstPhasePassed = false; });

            When(x => firstPhasePassed, () =>
            {

                RuleFor(x => x)
                .NotEmpty()
               .MustAsync((x, cancellation) => IsUserDevice(x)).WithMessage("Wrong Device Information");
            });
        }

        protected async Task<bool> IsUserDevice(AddPositionCommand command)
        {

            var device = await _vehicleRepository.IsCorrectDevice(_contextRepository.GetUserId(), command.DeviceId);
            if (!device)
            {
                return false;
            }

            return true;


        }
    }
}
