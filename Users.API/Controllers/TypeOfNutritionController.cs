namespace Users.API.Controllers ;
using System.Net;
using Aplication.Features.TypesOfNutrition.Queries.GetAllTypeOfNutrition;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class TypeOfNutritionController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllTypeOfNutritionResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllTypeOfNutritionResult>>> GetAll()
        {
            return await _mediator.Send(new GetAllTypeOfNutritionQuery());
        }
    }
