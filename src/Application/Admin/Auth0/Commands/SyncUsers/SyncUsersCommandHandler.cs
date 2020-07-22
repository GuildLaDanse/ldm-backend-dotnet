using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Abstractions;
using Auth0.Abstractions.Models;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Common;
using LaDanse.Common.Configuration;
using LaDanse.Domain.Entities.Identity;
using MediatR;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace LaDanse.Application.Admin.Auth0.Commands.SyncUsers
{
    public class SyncUsersCommandHandler : IRequestHandler<SyncUsersCommand>
    {
        private readonly ILogger _logger = Log.ForContext<SyncUsersCommand>();

        private readonly ILaDanseDbContext _dbContext;

        private readonly IConfiguration _configuration;

        private readonly IAuth0ApiClientFactory _auth0ApiClientFactory;

        private readonly IPasswordGenerator _passwordGenerator;

        public SyncUsersCommandHandler(
            ILaDanseDbContext dbContext,
            IConfiguration configuration,
            IAuth0ApiClientFactory auth0ApiClientFactory,
            IPasswordGenerator passwordGenerator)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _auth0ApiClientFactory = auth0ApiClientFactory;
            _passwordGenerator = passwordGenerator;
        }

        public async Task<Unit> Handle(SyncUsersCommand request, CancellationToken cancellationToken)
        {
            var auth0ApiClient = await _auth0ApiClientFactory.CreateClientAsync(
                _configuration.GetEnvironmentValue(EnvNames.Auth0Domain),
                _configuration.GetEnvironmentValue(EnvNames.Auth0Audience),
                _configuration.GetEnvironmentValue(EnvNames.Auth0ClientId),
                _configuration.GetEnvironmentValue(EnvNames.Auth0ClientSecret)
            );

            var authSearchUsersApi = auth0ApiClient.SearchUsersApi();

            var dbUsers = _dbContext.Users;

            _logger.Debug($"Got {dbUsers.Count()} users from database");

            foreach (var dbUser in dbUsers)
            {
                _logger.Debug($"Processing user {dbUser.Email}");

                var auth0Users = await authSearchUsersApi.SearchByEmailAsync(dbUser.Email.ToLower());

                switch (auth0Users.Length)
                {
                    case 0:
                        _logger.Debug("No Auth0 user, creating user");

                        await CreateAuth0User(dbUser, auth0ApiClient);
                        break;
                    case 1:
                    {
                        var auth0User = auth0Users[0];

                        _logger.Debug($"Got Auth0 user {auth0User.Email} - {auth0User.UserId}");

                        UpdateDbUser(dbUser, auth0User);
                        break;
                    }
                    default:
                        _logger.Warning($"More then one Auth0 users were found - {auth0Users.Length}");
                        break;
                }
            }

            _logger.Debug("Done syncing users");

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void UpdateDbUser(User dbUser, SearchUsersByEmail.User auth0User)
        {
            if (dbUser.ExternalId.Equals(auth0User.UserId)) return;

            _logger.Warning($"{dbUser.ExternalId} is not equal to {auth0User.UserId}");

            dbUser.ExternalId = auth0User.UserId;
        }

        private async Task CreateAuth0User(User dbUser, IAuth0ApiClient auth0ApiClient)
        {
            var managerUsersApi = auth0ApiClient.ManageUsersApi();

            var createUserRequest = new CreateUser.Request
            {
                Email = dbUser.Email,
                Blocked = false,
                EmailVerified = false,
                Nickname = dbUser.DisplayName,
                Connection = _configuration.GetEnvironmentValue(EnvNames.Auth0DefaultConnection),
                Password = _passwordGenerator.Generate(),
                VerifyEmail = false,
                AppMetaData = new CreateUser.AppMetaData
                {
                    LaDanseLegacyId = dbUser.Id.ToString()
                }
            };

            var createUserResponse = await managerUsersApi.CreateUserAsync(createUserRequest);

            dbUser.ExternalId = createUserResponse.UserId;
        }
    }
}