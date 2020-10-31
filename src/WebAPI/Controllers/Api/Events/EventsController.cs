using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using LaDanse.Application.Events.Models;
using LaDanse.Application.Events.Queries.GetAllEvents;
using LaDanse.Application.Events.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebAPI.Controllers.Api.Events
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ILogger _logger = Log.ForContext<EventsController>();
        
        [HttpGet("/api/events")]
        [Produces("application/json")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEventAsync(
            [FromQuery(Name = "fromDate")] string strFromDate,
            [FromServices] IMediator mediator)
        {
            if (!DateTime.TryParseExact(
                strFromDate, 
                "yyyyMMdd", 
                null, 
                DateTimeStyles.None, 
                out var fromDate))
            {
                fromDate = DateTime.Today;
            }
            
            var result = await mediator.Send(new GetAllEventsQuery(fromDate));

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