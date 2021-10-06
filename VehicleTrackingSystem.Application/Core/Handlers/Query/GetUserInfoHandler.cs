using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Query;
using VehicleTrackingSystem.Application.Core.Responses.Query;
using VehicleTrackingSystem.Infrastructure.Repositories.Interfaces;

namespace VehicleTrackingSystem.Application.Core.Handlers.Query
{
    public class GetUserInfoHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IContextRepository _contextRepository;

        public GetUserInfoHandler(IUserRepository userRepository,IContextRepository contextRepository)
        {
            _userRepository = userRepository;
            _contextRepository = contextRepository;
        }
        public async Task<GetUserInfoResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetUserById(_contextRepository.GetUserId());
            return result.Adapt<GetUserInfoResponse>();
        }
    }
}
