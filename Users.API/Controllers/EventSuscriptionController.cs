namespace Users.API.Controllers ;
using System.Net;
using Application.Features.ProductEventSuscriptions.Commands.ProductEventSuscriptionSave;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class EventSuscriptionController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ProductEventSuscriptionSaveResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductEventSuscriptionSaveResult>> CreateEventSuscriptionService(
            [FromBody] ProductEventSuscriptionSaveCommnand command)
        {
            return await _mediator.Send(command);
        }
    }
