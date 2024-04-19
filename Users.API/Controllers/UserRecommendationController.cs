namespace Users.API.Controllers ;
using System.Net;
using Application.Features.Recomendations.Query.GetRecomendationsById;
using Application.Features.Recomendations.Query.GetRecomendationsByUser;
using Application.Features.Recommendations.Query.GetRecomendationsById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRecommendationController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("ByUser")]
        [ProducesResponseType(typeof(GetRecommendationsByUserResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetRecommendationsByUserResult>>> GetByUser([FromBody] GetRecomendationsByUserQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("ById/{id}")]
        [ProducesResponseType(typeof(GetRecommendationsByIdResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetRecommendationsByIdResult>> GetById(Guid id)
        {
            return await _mediator.Send(new GetRecomendationsByIdQuery { Id = id });
        }
    }
