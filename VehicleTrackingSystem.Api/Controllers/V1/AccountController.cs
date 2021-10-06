using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Requests.Query;
using VehicleTrackingSystem.Utils.Routes;

namespace VehicleTrackingSystem.Api.Controllers.V1
{
    public class AccountController : BaseV1Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Account.Registration)]
        public async Task<IActionResult> Registration(RegistrationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Account.Login)]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            return Ok(await _mediator.Send(command));   
        }

    }
}
