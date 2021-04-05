using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Application.Events.Commands.CreateEvent;
using LaDanse.Application.Events.Models;
using LaDanse.Domain.Entities.Comments;
using LaDanse.ServiceBus.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Event = LaDanse.Domain.Entities.Events.Event;

namespace LaDanse.Application.Events.Commands.UpdateBasicEvent
{
    public class UpdateBasicEventCommandHandler : IRequestHandler<UpdateBasicEventCommand>
    {
        private readonly ILogger _logger = Log.ForContext<CreateEventCommandHandler>();

        private readonly ILaDanseDbContext _dbContext;
        private readonly IServiceBus _serviceBus;
        private readonly ILaDanseRuntimeContext _laDanseRuntimeContext;

        public UpdateBasicEventCommandHandler(
            ILaDanseRuntimeContext laDanseRuntimeContext,
            IServiceBus serviceBus,
            ILaDanseDbContext dbContext)
        {
            _dbContext = dbContext;
            _serviceBus = serviceBus;
            _laDanseRuntimeContext = laDanseRuntimeContext;
        }
        
        public async Task<Unit> Handle(
            UpdateBasicEventCommand request, 
            CancellationToken cancellationToken)
        {
            /* (1) Verify validity of input */

            ValidateRequest(request, cancellationToken);
            
            /* (2) Verify if person trying to create event is allowed to create an event */
            
            // TODO
            
            /* (3) Create event */

            var updatedEvent = await HandleRequestAsync(request, cancellationToken);
            
            /* (4) Send out an integration event to indicate an event was created */

            SendIntegrationEvent(request, updatedEvent);

            return Unit.Value;
        }

        private void ValidateRequest(
            UpdateBasicEventCommand request, 
            CancellationToken cancellationToken)
        {
            /*
             * - Name cannot be empty (minimum length)
             * - Invite, Start and End Time must be on the same day
             * - Invite Time <= Start Time < End Time
             * - Invite, Start and End Time cannot be in the past
             *      - unless Admin or Officer?
             */
        }

        private async Task<Event> HandleRequestAsync(
            UpdateBasicEventCommand request, 
            CancellationToken cancellationToken)
        {
            var dbEvent = await _dbContext.Events.FirstOrDefaultAsync(
                e => e.Id == request.EventId, 
                cancellationToken);

            if (dbEvent == null)
            {
                // TODO NotFoundException

                throw new Exception("Not Found");
            }

            dbEvent.Name = request.UpdateBasicEvent.Name;
            dbEvent.Description = request.UpdateBasicEvent.Description;
            dbEvent.InviteTime = request.UpdateBasicEvent.InviteTime;
            dbEvent.StartTime = request.UpdateBasicEvent.StartTime;
            dbEvent.EndTime = request.UpdateBasicEvent.EndTime;
            
            _logger.Debug($"Updated event with id {dbEvent.Id}");
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            return dbEvent;
        }
        
        private void SendIntegrationEvent(
            UpdateBasicEventCommand request, 
            Event newEvent)
        {
            _serviceBus.GetTopic("IntegrationEvents").SendMessage("Event updated");
        }
    }
}