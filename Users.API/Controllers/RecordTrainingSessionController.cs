namespace Users.API.Controllers ;
using System.Net;
using Application.Features.RecordTrainingSessions.Commads;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class RecordTrainingSessionController(IMediator _mediator) : ControllerBase
    {
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        [HttpPost("Save")]
        public async Task<ActionResult<Unit>> SaveRecordTrainingSession([FromBody] RecordTrainingSessionsCreateCommand command)
        {
            return await _mediator.Send(command);
        }
    }
