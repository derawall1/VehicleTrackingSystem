using MediatR;
using VehicleTrackingSystem.Application.Core.Responses.Command;


namespace VehicleTrackingSystem.Application.Core.Requests.Command
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
