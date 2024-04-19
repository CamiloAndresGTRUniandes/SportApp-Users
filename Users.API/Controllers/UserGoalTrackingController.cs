namespace Users.API.Controllers ;
using System.Net;
using Application.Features.UserGoalTrackings.Command.UserGoalTrackingSave;
using Application.Features.UserGoalTrackings.Queries.UserGoalTrackingByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserGoalTrackingController(IMediator _mediator) : ControllerBase
    {
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        [HttpPost("Save")]
        public async Task<ActionResult<Unit>> SaveUserGoalTracking([FromBody] UserGoalTrackingSaveCommand command)
        {
            return await _mediator.Send(command);
        }

        [ProducesResponseType(typeof(UserGoalTrackingByUserIdResult), (int)HttpStatusCode.OK)]
        [HttpGet("GetByUserId/{userId}")]
        public async Task<ActionResult<UserGoalTrackingByUserIdResult>> SaveUserGoalTracking(string userId)
        {
            return await _mediator.Send(new UserGoalTrackingByUserIdQuery { UserId = userId });
        }
    }
