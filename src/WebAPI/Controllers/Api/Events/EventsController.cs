using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaDanse.Application.Admin.Auth0.Commands.SyncUsers;
using LaDanse.Application.Events.Models;
using LaDanse.Application.Events.Queries.GetAllEvents;
using LaDanse.Application.Events.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Api.Events
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet("/api/events")]
        [Produces("application/json")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEventAsync([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new GetAllEventsQuery());

            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }
        
        [HttpGet("/api/events/{eventId}")]
        [Produces("application/json")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Event>> GetEventAsync([FromServices] IMediator mediator, string eventId)
        {
            var gEventId = Guid.Parse(eventId);
            
            var result = await mediator.Send(new GetEventQuery(gEventId));

            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }
    }
}