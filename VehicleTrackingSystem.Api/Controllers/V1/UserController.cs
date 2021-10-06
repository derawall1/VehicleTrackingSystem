using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Requests.Query;
using VehicleTrackingSystem.Utils.Routes;

namespace VehicleTrackingSystem.Api.Controllers.V1
{
    public class UserController : BaseV1Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet(ApiRoutes.User.GetUserInfo)]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok(await _mediator.Send(new GetUserInfoQuery()));
        }
        
        [Authorize]
        [HttpPut(ApiRoutes.User.Update)]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}