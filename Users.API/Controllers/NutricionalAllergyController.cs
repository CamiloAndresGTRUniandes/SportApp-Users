namespace Users.API.Controllers ;
using System.Net;
using Aplication.Features.NutritionalAllergies.Queries.GetAllNutionalAllergies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class NutricionalAllergyController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllNutionalAllergiesResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllNutionalAllergiesResult>>> GetAll()
        {
            return await _mediator.Send(new GetAllNutionalAllergiesQuery());
        }
    }
