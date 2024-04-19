namespace Users.API.Controllers ;
using System.Net;
using Aplication.Features.Genres.Queries.GetAllGenre;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllGenresResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllGenresResult>>> GetAll()
        {
            return await _mediator.Send(new GetAllGenresQuery());
        }
    }
