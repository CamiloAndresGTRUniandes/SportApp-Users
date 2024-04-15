using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Users.Aplication.Features.PhysicalLevels.Queries.GetAllPhysicalLeve;

namespace Users.API.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class PhysicalLevelController(IMediator _mediator) : ControllerBase
    {


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllPhysicalResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllPhysicalResult>>> GetAll()
        => await _mediator.Send(new GetAllPhysicalQuery());

    }
}
