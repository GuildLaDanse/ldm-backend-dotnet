using System.Threading.Tasks;
using LaDanse.Application.Admin.Auth0.Commands.DeleteAllUsers;
using LaDanse.Application.Admin.Auth0.Commands.SyncUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Api.Admin
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("/api/admin/users/sync-auth0")]
        [Authorize(Roles = "admin")]
        public async Task Sync([FromServices] IMediator mediator)
        {
            await mediator.Send(new SyncUsersCommand());
        }
        
        [HttpGet("/api/admin/users/delete-all")]
        [Authorize(Roles = "admin")]
        public async Task DeleteAll([FromServices] IMediator mediator)
        {
            await mediator.Send(new DeleteAllUsersCommand());
        }
    }
}