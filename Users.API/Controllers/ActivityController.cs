namespace Users.API.Controllers ;
using System.Net;
using Aplication.Features.Activities.Queries.GetAllActivities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivityController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllActivitiesResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllActivitiesResult>>> GetAll()
        {
            return await _mediator.Send(new GetAllActivitiesQuery());
        }
    }
