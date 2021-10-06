using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;
using VehicleTrackingSystem.Utils;

namespace VehicleTrackingSystem.Application.Validators
{
    public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegistrationCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            bool firstPhasePassed = true;

            RuleFor(e => e.FirstName)
                .NotEmpty()
                .Length(0, 100)
                .OnAnyFailure(x => { firstPhasePassed = false; });
            RuleFor(e => e.LastName)
                .NotEmpty()
                .Length(0, 100)
                .OnAnyFailure(x => { firstPhasePassed = false; });
            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("A valid email is required")
                .OnAnyFailure(x => { firstPhasePassed = false; });


            RuleFor(e => e.Password).NotEmpty()
             .OnAnyFailure(x => { firstPhasePassed = false; });

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("Password and Confirm Password does not match")
                .OnAnyFailure(x => { firstPhasePassed = false; });


            When(x => firstPhasePassed, () =>
            {
                RuleFor(x => x)
                .NotEmpty()
               .MustAsync((x, cancellation) => IsEmailExists(x)).WithMessage("Email Must be unique");
            });
        }

        protected async Task<bool> IsEmailExists(RegistrationCommand command)
        {
            var user = await _userRepository.GetUserByEmail(command.Email);
            if (user != null)
            {
                return false;

            }
            return true;
        }
    }

}
