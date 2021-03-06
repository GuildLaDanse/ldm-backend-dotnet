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

namespace LaDanse.WebAPI.Controllers.Api.Events
{
    [ApiController]
    public class EventsQueryController : ControllerBase
    {
        private readonly ILogger _logger = Log.ForContext<EventsQueryController>();
        
        [HttpGet("/api/events")]
        [Produces("application/json")]
        [Authorize]
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
            
            try
            {
                var result = await mediator.Send(new GetAllEventsQuery
                {
                    StartDate = fromDate
                });

                if (result == null)
                {
                    return NotFound();
                }
            
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.InternalError);
                
                return Problem(ErrorMessages.InternalError);
            }
        }
        
        [HttpGet("/api/events/{eventId}")]
        [Produces("application/json")]
        [Authorize]
        public async Task<ActionResult<Event>> GetEventAsync(
            [FromServices] IMediator mediator, 
            string eventId)
        {
            Guid gEventId;

            try
            {
                gEventId = Guid.Parse(eventId);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.InvalidGuidIdentifier);
                
                return BadRequest(ErrorMessages.InvalidGuidIdentifier);
            }

            try
            {
                var result = await mediator.Send(new GetEventQuery
                {
                    EventId = gEventId
                });

                if (result == null)
                {
                    return NotFound();
                }
                
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.InternalError);
                
                return Problem(ErrorMessages.InternalError);
            }
        }
    }
}