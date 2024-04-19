namespace Users.API.Controllers ;
using System.Net;
using Application.Features.Recomendations.Query.GetRecomendationsByAsociate;
using Application.Features.Recomendations.Query.GetRecomendationsByUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserNotificationController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("ByUser")]
        [ProducesResponseType(typeof(GetRecomendationsByUserResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetRecomendationsByUserResult>>> GetByUser([FromBody] GetRecomendationsByUserQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("ByAsociate/{asociateId}")]
        [ProducesResponseType(typeof(GetRecomendationsByUserResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetRecomendationsByAsociateResult>>> GetByAsociate(string asociateId)
        {
            return await _mediator.Send(new GetRecomendationsByAsociateQuery
            {
                UserId = asociateId
            }
                );
        }
    }
