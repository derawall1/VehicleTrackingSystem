using FluentValidation;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;
using VehicleTrackingSystem.Utils;

namespace VehicleTrackingSystem.Application.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        private readonly IUserRepository _userRepository;

        public LoginCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            bool firstPhasePassed = true;

            RuleFor(e => e.Email).NotEmpty()
                 .OnAnyFailure(x => { firstPhasePassed = false; });
            RuleFor(e => e.Password).NotEmpty()
              .OnAnyFailure(x => { firstPhasePassed = false; });

            When(x => firstPhasePassed, () =>
            {

                RuleFor(x => x)
                .NotEmpty()
               .MustAsync((x, cancellation) => IsAuthorized(x)).WithMessage("Wrong email or password");
            });

        }

        protected async Task<bool> IsAuthorized(LoginCommand command)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(command.Email);
                if (user == null)
                {
                    return false;

                }
                else if (!Authenticator.ValidatePassword(command.Password, user.Password))
                {
                    return false;

                }
                return true;
            }
            catch (System.Exception ex)
            {

                return false;

            }

        }
    }
}
