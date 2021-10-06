using FluentValidation;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty()
                .Length(0, 100);
            RuleFor(e => e.LastName)
                .NotEmpty()
                .Length(0, 100);
        }
    }

}
