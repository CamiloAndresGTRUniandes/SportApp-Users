namespace Users.API.Controllers ;
using System.Net;
using Aplication.Features.Goals.Queries.GetAllGoals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class GoalController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllGoalsResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllGoalsResult>>> GetAll()
        {
            return await _mediator.Send(new GetAllGoalsQuery());
        }
    }
