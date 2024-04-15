using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Users.Aplication.Features.NutritionalAllergies.Queries.GetAllNutionalAllergies;

namespace Users.API.Controllers
{

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class NutricionalAllergyController(IMediator _mediator) :  ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllNutionalAllergiesResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllNutionalAllergiesResult>>> GetAll()
      => await _mediator.Send(new GetAllNutionalAllergiesQuery());

    }
}
