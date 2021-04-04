using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LaDanse.Application.Common.Extensions;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Application.Events.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LaDanse.Application.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Event>> 
    {
        private readonly ILogger _logger = Log.ForContext<GetAllEventsQueryHandler>();

        private readonly ILaDanseDbContext _dbContext;

        public GetAllEventsQueryHandler(ILaDanseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var dbUsers = _dbContext.Users;
            
            var lastDate = request.StartDate.AddDays(28).ChangeTime(23, 59, 59);

            var dbEvents = await _dbContext.Events
                .Where(e => e.InviteTime.CompareTo(request.StartDate) >= 0)
                .Where(e => e.InviteTime.CompareTo(lastDate) <= 0)
                .OrderBy(e => e.InviteTime)
                .Include(e => e.Organiser)
                .ToListAsync(cancellationToken);

            var eventModels = new List<Event>();

            foreach (var dbEvent in dbEvents)
            {
                var dbSignups = await _dbContext.SignUps
                    .Where(s => s.EventId == dbEvent.Id)
                    .Include(s => s.User)
                    .ToListAsync(cancellationToken);

                var signUpIds = dbSignups.Select(s => s.Id);

                var dbSignedForGameRoles = await _dbContext.SignedForGameRoles
                    .Where(s => signUpIds.Contains(s.SignUpId))
                    .ToListAsync(cancellationToken);
                
                var signUps = dbSignups.Select(
                    s => new SignUp
                    {
                        Id = s.Id,
                        UserRef = new UserReference(s.UserId, s.User.DisplayName),
                        Type = s.Type.ToString(),
                        Roles = dbSignedForGameRoles
                            .Where(r => r.SignUpId == s.Id)
                            .Select(r => r.GameRole.ToString())
                    });
                
                var eventModel = new Event
                {
                    Id = dbEvent.Id,
                    Name = dbEvent.Name,
                    Description = dbEvent.Description,
                    OrganiserRef = new UserReference(dbEvent.OrganiserId, dbEvent.Organiser.DisplayName),
                    InviteTime = dbEvent.InviteTime,
                    StartTime = dbEvent.StartTime,
                    EndTime = dbEvent.EndTime,
                    State = dbEvent.State.ToString(),
                    CommentGroupRef = new CommentGroupReference(dbEvent.CommentGroupId),
                    SignUps = signUps
                };
                
                eventModels.Add(eventModel);
            }
            
            return eventModels;
        }
    }
}