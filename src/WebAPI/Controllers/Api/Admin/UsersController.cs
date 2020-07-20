using System.Threading.Tasks;
using LaDanse.Application.Admin.Auth0.Commands.SyncUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Api.Admin
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("/api/admin/users/sync")]
        [Authorize(Roles = "admin")]
        public async Task Sync([FromServices] IMediator mediator)
        {
            await mediator.Send(new SyncUsersCommand());
        }
    }
}