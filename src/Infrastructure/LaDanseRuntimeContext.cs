using System;
using System.Linq;
using System.Security.Claims;
using LaDanse.Application;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;

namespace LaDanse.Infrastructure
{
    public class LaDanseRuntimeContext : ILaDanseRuntimeContext
    {
        private const string NameIdentifierType =
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        
        private readonly ILaDanseDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private User _user;
        
        public LaDanseRuntimeContext(
            ILaDanseDbContext dbContext,
            IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;

            LoadUser();
        }
        
        public ClaimsPrincipal ClaimsPrincipal()
        {
            return _httpContextAccessor.HttpContext.User;
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
        
        public Guid UserId()
        {
            VerifyUser();

            return _user.Id;
        }

        public User User()
        {
            VerifyUser();

            return _user;
        }

        private void LoadUser()
        {
            if (!IsAuthenticated())
            {
                return;
            }
            
            var externalId = ClaimsPrincipal().Claims
                .First(c => c.Type == NameIdentifierType).Value;

            // TODO this is not correct, fix!
            _user = _dbContext.Users.FirstOrDefault(u => u.UserName == externalId);
        }
        
        private void VerifyUser()
        {
            if (_user == null || !IsAuthenticated())
            {
                throw new Exception("Http session is not authenticated, cannot fetch User from database");
            }
        }
    }
}