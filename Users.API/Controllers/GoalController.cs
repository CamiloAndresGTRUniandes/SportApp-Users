using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Users.Aplication.Features.Goals.Queries.GetAllGoals;

namespace Users.API.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class GoalController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllGoalsResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllGoalsResult>>> GetAll()
            => await _mediator.Send(new GetAllGoalsQuery());
    }
}
