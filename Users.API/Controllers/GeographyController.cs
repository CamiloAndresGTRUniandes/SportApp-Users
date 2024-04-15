namespace Users.API.Controllers ;
using System.Net;
using Aplication.Features.Cities.Queries.GetCityById;
using Aplication.Features.Cities.Queries.GetCityByState;
using Aplication.Features.Countries.Queries.GetAllCountry;
using Aplication.Features.States.Queries.GetStatesByCountry;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GeographyController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("AllCountries")]
        [ProducesResponseType(typeof(IEnumerable<GetAllCountryResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllCountryResult>>> GetAll()
        {
            return await _mediator.Send(new GetAllCountryQuery());
        }

        [HttpGet("StatesByCountry/{countryId}")]
        [ProducesResponseType(typeof(IEnumerable<GetStatesByCountryResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetStatesByCountryResult>>> GetStatesByCountry(Guid countryId)
        {
            return await _mediator.Send(new GetStatesByCountryQuery { CountryId = countryId });
        }

        [HttpGet("CitiesByState/{stateId}")]
        [ProducesResponseType(typeof(IEnumerable<GetCityByStateResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetCityByStateResult>>> GetCitiesByState(Guid stateId)
        {
            return await _mediator.Send(new GetCityByStateQuery { StateId = stateId });
        }


        [HttpGet("CitiesById/{cityId}")]
        [ProducesResponseType(typeof(IEnumerable<GetCityByIdResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetCityByIdResult>>> GetCitiesById(Guid cityId)
        {
            return await _mediator.Send(new GetCityByIdQuery { CityId = cityId });
        }
    }
