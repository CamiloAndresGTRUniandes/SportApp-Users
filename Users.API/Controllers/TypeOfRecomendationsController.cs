namespace Users.API.Controllers ;
using System.Net;
using Application.Features.TypeOfRecomendations.Queries.GetAllTypeOfRecomendations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class TypeOfRecomendationsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllTypeOfRecomendationsResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetAllTypeOfRecomendationsResult>>> GetAll()
        {
            return await _mediator.Send(new GetAllTypeOfRecomendationsQuery());
        }
    }
