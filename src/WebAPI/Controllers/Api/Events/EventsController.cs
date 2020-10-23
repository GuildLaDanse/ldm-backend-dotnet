using System.Threading.Tasks;
using LaDanse.Application.Admin.Auth0.Commands.SyncUsers;
using LaDanse.Application.Events.Models;
using LaDanse.Application.Events.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Api.Events
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet("/api/events/{eventId}")]
        [Produces("application/json")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Event>> GetEventAsync([FromServices] IMediator mediator, string eventId)
        {
            var result = await mediator.Send(new GetEventQuery(eventId));

            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }
    }
}