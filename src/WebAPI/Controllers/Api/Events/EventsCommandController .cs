using System;
using System.Threading.Tasks;
using LaDanse.Application.Events.Models;
using LaDanse.Application.Events.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LaDanse.WebAPI.Controllers.Api.Events
{
    [ApiController]
    public class EventsCommandController : ControllerBase
    {
        private readonly ILogger _logger = Log.ForContext<EventsCommandController>();
        
        [HttpPost("/api/events")]
        [Produces("application/json")]
        public async Task<ActionResult<Guid>> CreateEventAsync(
            [FromQuery(Name = "fromDate")] string strFromDate,
            [FromServices] IMediator mediator)
        {
            return Guid.NewGuid();
        }
        
        [HttpPut("/api/events/{eventId}/basic")]
        [Produces("application/json")]
        public async Task<ActionResult<Event>> UpdateCoreEventAsync(
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
                var result = await mediator.Send(new GetEventQuery(gEventId));

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
        
        [HttpPut("/api/events/{eventId}/state")]
        [Produces("application/json")]
        public async Task<ActionResult<Event>> UpdateStateEventAsync(
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
                var result = await mediator.Send(new GetEventQuery(gEventId));

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
        
        [HttpDelete("/api/events/{eventId}")]
        [Produces("application/json")]
        public async Task<ActionResult<Event>> DeleteEventAsync(
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
                var result = await mediator.Send(new GetEventQuery(gEventId));

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
        
        // Post Sign Up (create Sign Up)
        
        // Put Sign Up (update Sign Up)
        
        // Delete Sign Up (remove Sign Up)
    }
}