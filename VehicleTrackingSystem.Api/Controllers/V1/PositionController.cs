using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VehicleTrackingSystem.Application.Core.Requests.Command;
using VehicleTrackingSystem.Application.Core.Requests.Query;
using VehicleTrackingSystem.Application.Services;
using VehicleTrackingSystem.Utils.Routes;

namespace VehicleTrackingSystem.Api.Controllers.V1
{
    public class PositionController : BaseV1Controller
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost(ApiRoutes.Position.Add)]
        public async Task<IActionResult> AddPosition(AddPositionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpGet(ApiRoutes.Position.CurrentPosition)]
        public async Task<IActionResult> GetCurrentPosition(long vehicleId)
        {
            return Ok(await _mediator.Send(new GetCurrentPositionQuery { VehicleId = vehicleId }));
        }

        [Authorize]
        [HttpGet(ApiRoutes.Position.Journey)]
        public async Task<IActionResult> GetJourney(long vehicleId, DateTime start, DateTime end)
        {
            return Ok(await _mediator.Send(new GetJourneyQuery { VehicleId = vehicleId, Start = start.ToUniversalTime(), End = end.ToUniversalTime() }));
        }


    }
}
