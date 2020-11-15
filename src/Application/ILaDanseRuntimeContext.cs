using System;
using System.Security.Claims;
using LaDanse.Domain.Entities.Identity;

namespace LaDanse.Application
{
    public interface ILaDanseRuntimeContext
    {
        ClaimsPrincipal ClaimsPrincipal();

        bool IsAuthenticated();

        Guid UserId();
        
        User User();
    }
}