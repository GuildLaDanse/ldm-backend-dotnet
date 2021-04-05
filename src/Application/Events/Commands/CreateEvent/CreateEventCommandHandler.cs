using System;
using System.Threading;
using System.Threading.Tasks;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Domain.Entities.Comments;
using LaDanse.Domain.Entities.Events;
using LaDanse.ServiceBus.Abstractions;
using MediatR;
using Serilog;

namespace LaDanse.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly ILogger _logger = Log.ForContext<CreateEventCommandHandler>();

        private readonly ILaDanseDbContext _dbContext;
        private readonly IServiceBus _serviceBus;
        private readonly ILaDanseRuntimeContext _laDanseRuntimeContext;

        public CreateEventCommandHandler(
            ILaDanseRuntimeContext laDanseRuntimeContext,
            IServiceBus serviceBus,
            ILaDanseDbContext dbContext)
        {
            _dbContext = dbContext;
            _serviceBus = serviceBus;
            _laDanseRuntimeContext = laDanseRuntimeContext;
        }
        
        public async Task<Guid> Handle(
            CreateEventCommand request, 
            CancellationToken cancellationToken)
        {
            /* (1) Verify validity of input */

            ValidateRequest(request, cancellationToken);
            
            /* (2) Verify if person trying to create event is allowed to create an event */
            
            // TODO
            
            /* (3) Create event */

            var newEvent = await HandleRequestAsync(request, cancellationToken);
            
            /* (4) Send out an integration event to indicate an event was created */

            SendIntegrationEvent(request, newEvent);

            return newEvent.Id;
        }

        private void ValidateRequest(
            CreateEventCommand request, 
            CancellationToken cancellationToken)
        {
            /*
             * - Name cannot be empty (minimum length)
             * - Invite, Start and End Time must be on the same day
             * - Invite Time <= Start Time < End Time
             * - Invite, Start and End Time cannot be in the past
             *      - unless Admin or Office?
             */
        }

        private async Task<Event> HandleRequestAsync(
            CreateEventCommand request, 
            CancellationToken cancellationToken)
        {
            var newCommentGroup = new CommentGroup
            {
                Id = Guid.NewGuid(),
                PostDate = DateTime.Now.ToUniversalTime()
            };
            
            _logger.Debug($"Created new comment group for event with id {newCommentGroup.Id}");

            var newEvent = new Event
            {
                Id = Guid.NewGuid(),
                Name = request.CreateEvent.Name,
                Description = request.CreateEvent.Description,
                InviteTime = request.CreateEvent.InviteTime.ToUniversalTime(),
                StartTime = request.CreateEvent.InviteTime.ToUniversalTime(),
                EndTime = request.CreateEvent.EndTime.ToUniversalTime(),
                OrganiserId = _laDanseRuntimeContext.UserId(),
                CommentGroupId = newCommentGroup.Id,
                LastModifiedTime = DateTime.Now.ToUniversalTime()
            };
            
            _logger.Debug($"Created new event with id {newEvent.Id}");

            await _dbContext.CommentGroups.AddAsync(newCommentGroup, cancellationToken);
            await _dbContext.Events.AddAsync(newEvent, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return newEvent;
        }
        
        private void SendIntegrationEvent(
            CreateEventCommand request, 
            Event newEvent)
        {
            _serviceBus.GetTopic("IntegrationEvents").SendMessage("New event created");
        }
    }
}