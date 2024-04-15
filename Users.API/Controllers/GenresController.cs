using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Users.Aplication.Features.Genres.Queries.GetAllGenre;

namespace Users.API.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllGenresResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllGenresResult>>> GetAll()
        => await _mediator.Send(new GetAllGenresQuery());

    }
}
