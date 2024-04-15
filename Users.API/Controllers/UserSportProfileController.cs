namespace Users.API.Controllers ;
using System.Net;
using Aplication.Features.UsersSportProfile.Command.UpdateUserProfile;
using Aplication.Features.UsersSportProfile.Queries.GetUserById;
using Application.Features.UsersSportProfile.Queries.GetUsersFilters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserSportProfileController(IMediator _mediator) : ControllerBase
    {
        [HttpPut]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Update([FromBody] UpdateUserSportProfileCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserByIdQueryResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUserByIdQueryResult>> GetById(string id)
        {
            return await _mediator.Send(new GetUserByIdQuery { UserId = id });
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(GetUserByIdQueryResult), (int)HttpStatusCode.OK)]
        [HttpPost("filters-user")]
        public async Task<ActionResult<List<GetUsersFiltersResult>>> FiltersUser([FromBody] GetUsersFiltersQuery filter)
        {
            return await _mediator.Send(filter);
        }
    }
