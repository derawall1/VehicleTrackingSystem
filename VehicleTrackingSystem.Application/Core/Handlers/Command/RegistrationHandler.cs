using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Responses.Command;
using VehicleTrackingSystem.Infrastructure.Domain.Entities;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;
using VehicleTrackingSystem.Utils;

namespace VehicleTrackingSystem.Application.Core.Handlers.Command
{
    public class RegistrationHandler : IRequestHandler<RegistrationCommand, RegistrationResponse>
    {
        private readonly IUserRepository _userRepository;

        public RegistrationHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<RegistrationResponse> Handle(RegistrationCommand command, CancellationToken cancellationToken)
        {
            var user = command.Adapt<User>();
            user.Password = Authenticator.GetHashPassword(command.Password);
            var result = await _userRepository.InsertUser(user);
            return result.Adapt<RegistrationResponse>();
        }
    }
  
}
