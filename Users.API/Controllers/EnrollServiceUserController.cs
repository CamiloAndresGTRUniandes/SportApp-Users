namespace Users.API.Controllers ;
using System.Net;
using Application.Features.EnrollServiceUsers.Commands.CreateEnrollServiceUser;
using Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationsByAsociate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationById;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class EnrollServiceUserController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateEnrollServiceUserResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateEnrollServiceUserResult>> CreateEnrollService([FromBody] CreateEnrollServiceUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("ByAsociate/{asociateId}")]
        [ProducesResponseType(typeof(GetEnrollRecomendationsByAsociateResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetEnrollRecomendationsByAsociateResult>>> GetByAsociate(string asociateId)
        {
            return await _mediator.Send(new GetEnrollRecomendationsByAsociateQuery
            {
                UserId = asociateId
            }
                );
        }

        [HttpGet("ById/{id}")]
        [ProducesResponseType(typeof(GetEnrollRecomendationsByIdResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEnrollRecomendationsByIdResult>> GetById(Guid id)
        {
            return await _mediator.Send(new GetEnrollRecomendationsByIdQuery()
            {
                Id = id
            }
                );
        }
}
