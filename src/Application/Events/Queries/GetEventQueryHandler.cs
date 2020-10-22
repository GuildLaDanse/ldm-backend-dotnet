using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LaDanse.Application.Admin.Auth0.Commands.SyncUsers;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Application.Events.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LaDanse.Application.Events.Queries
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, EventDto> 
    {
        private readonly ILogger _logger = Log.ForContext<SyncUsersCommand>();

        private readonly ILaDanseDbContext _dbContext;

        public GetEventQueryHandler(ILaDanseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<EventDto> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var dbUsers = _dbContext.Users;

            var dbEvent = await _dbContext.Events
                .Where(e => e.Id == Guid.Parse((request.EventId)))
                .FirstOrDefaultAsync(cancellationToken);

            if (dbEvent == null)
            {
                return null;
            }

            var eventDto = new EventDto
            {
                Name = dbEvent.Name,
                OrganiserId = dbEvent.OrganiserId.ToString()
            };
            
            return eventDto;
        }
    }
}