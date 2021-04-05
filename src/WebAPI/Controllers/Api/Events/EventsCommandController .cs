using System;
using System.Threading.Tasks;
using LaDanse.Application.Events.Commands.CreateEvent;
using LaDanse.Application.Events.Commands.UpdateBasicEvent;
using LaDanse.Application.Events.Models;
using LaDanse.Application.Events.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<EventCreated>> CreateEventAsync(
            [FromBody] CreateEvent createEvent,
            [FromServices] IMediator mediator)
        {
            var createEventCmd = new CreateEventCommand
            {
                CreateEvent = createEvent
            };

            return await mediator.Send(createEventCmd);
        }
        
        [HttpPut("/api/events/{eventId}/basic")]
        [Produces("application/json")]
        public async Task<ActionResult<Event>> UpdateCoreEventAsync(
            [FromServices] IMediator mediator, 
            string eventId,
            [FromBody] UpdateBasicEvent updateBasicEvent)
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
                await mediator.Send(new UpdateBasicEventCommand
                {
                    EventId = gEventId,
                    UpdateBasicEvent = updateBasicEvent
                });
                
                return Ok();
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
        
        // Post Sign Up (CreateSignUp)
        
        // Put Sign Up (UpdateSignUp)
        
        // Delete Sign Up (DeleteSignUp)
    }
}