using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LaDanse.Application.Admin.Auth0.Commands.SyncUsers;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Common.Abstractions;
using LaDanse.External.Auth0.Abstractions;
using LaDanse.External.Configuration.Abstractions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace LaDanse.Application.Admin.Auth0.Commands.DeleteAllUsers
{
    public class DeleteAllUsersCommandHandler : IRequestHandler<DeleteAllUsersCommand>
    {
        private readonly ILogger _logger = Log.ForContext<SyncUsersCommand>();

        private readonly ILaDanseDbContext _dbContext;

        private readonly ILaDanseConfiguration _configuration;

        private readonly IAuth0ApiClientFactory _auth0ApiClientFactory;

        private readonly IPasswordGenerator _passwordGenerator;

        public DeleteAllUsersCommandHandler(
            ILaDanseDbContext dbContext,
            ILaDanseConfiguration configuration,
            IAuth0ApiClientFactory auth0ApiClientFactory,
            IPasswordGenerator passwordGenerator)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _auth0ApiClientFactory = auth0ApiClientFactory;
            _passwordGenerator = passwordGenerator;
        }

        public async Task<Unit> Handle(DeleteAllUsersCommand request, CancellationToken cancellationToken)
        {
            // commented out as this is very dangerous code only used during initial development
            /*
            var auth0ApiClient = await _auth0ApiClientFactory.CreateClientAsync(
                _configuration.GetEnvironmentValue(EnvNames.Auth0Domain),
                _configuration.GetEnvironmentValue(EnvNames.Auth0Audience),
                _configuration.GetEnvironmentValue(EnvNames.Auth0ClientId),
                _configuration.GetEnvironmentValue(EnvNames.Auth0ClientSecret)
            );

            var manageUsersApi = auth0ApiClient.ManageUsersApi();

            var dbUsers = _dbContext.Users;

            _logger.Debug($"Got {dbUsers.Count()} users from database");

            foreach (var dbUser in dbUsers)
            {
                _logger.Debug($"Deleting user {dbUser.Email}");

                manageUsersApi.DeleteUserAsync(dbUser.ExternalId);
            }

            _logger.Debug("Done deleting all users");
            */

            return Unit.Value;
        }
    }
}