using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Responses.Command;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Core.Handlers.Command
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IContextRepository _contextRepository;

        public UpdateUserHandler(IUserRepository userRepository, IContextRepository contextRepository)
        {
            _userRepository = userRepository;
            _contextRepository = contextRepository;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = command.Adapt<User>();
            user.Id = _contextRepository.GetUserId();
            var result = await _userRepository.UpdateUser(user);
            return result.Adapt<UpdateUserResponse>();
        }
    }  
  
}
