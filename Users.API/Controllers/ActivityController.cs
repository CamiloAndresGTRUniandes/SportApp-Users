using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Users.Aplication.Features.Activities.Queries.GetAllActivities;

namespace Users.API.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivityController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllActivitiesResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllActivitiesResult>>> GetAll()
       => await _mediator.Send(new GetAllActivitiesQuery());
    }
}
