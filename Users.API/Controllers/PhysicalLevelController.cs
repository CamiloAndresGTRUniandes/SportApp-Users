namespace Users.API.Controllers ;
using System.Net;
using Aplication.Features.PhysicalLevels.Queries.GetAllPhysicalLeve;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class PhysicalLevelController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllPhysicalResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllPhysicalResult>>> GetAll()
        {
            return await _mediator.Send(new GetAllPhysicalQuery());
        }
    }
