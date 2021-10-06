using MediatR;
using VehicleTrackingSystem.Application.Core.Responses.Command;

namespace VehicleTrackingSystem.Application.Core.Requests.Command
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
