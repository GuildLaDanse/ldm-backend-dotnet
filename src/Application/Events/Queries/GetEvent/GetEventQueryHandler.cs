using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Application.Events.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LaDanse.Application.Events.Queries.GetEvent
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, Event> 
    {
        private readonly ILogger _logger = Log.ForContext<GetEventQueryHandler>();

        private readonly ILaDanseDbContext _dbContext;

        public GetEventQueryHandler(ILaDanseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Event> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var dbUsers = _dbContext.Users;

            var dbEvent = await _dbContext.Events
                .Where(e => e.Id == request.EventId)
                .Include(e => e.Organiser)
                .FirstOrDefaultAsync(cancellationToken);

            if (dbEvent == null)
            {
                return null;
            }

            var dbSignups = await _dbContext.SignUps
                .Where(s => s.EventId == dbEvent.Id)
                .Include(s => s.User)
                .ToListAsync(cancellationToken);

            var signUpIds = dbSignups.Select(s => s.Id);

            var dbSignedForGameRoles = await _dbContext.SignedForGameRoles
                .Where(s => signUpIds.Contains(s.SignUpId))
                .ToListAsync(cancellationToken);
            
            _logger.Debug("dbSignedForGameRoles size " + dbSignedForGameRoles.Count);
            
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
            
            return new Event
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
        }
    }
}