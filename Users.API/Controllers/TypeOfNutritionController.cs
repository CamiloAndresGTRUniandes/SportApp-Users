using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Users.Aplication.Features.TypesOfNutrition.Queries.GetAllTypeOfNutrition;

namespace Users.API.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class TypeOfNutritionController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllTypeOfNutritionResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllTypeOfNutritionResult>>> GetAll()
            => await _mediator.Send(new GetAllTypeOfNutritionQuery());
    }
}
