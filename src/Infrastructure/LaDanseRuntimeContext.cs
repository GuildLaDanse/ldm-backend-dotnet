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
            VerifyAndLoadUser();

            return _user.Id;

            var strUserId = ClaimsPrincipal().Claims
                .First(c => c.Type == "https://www.ladanse.org/ladanse_legacy_id").Value;
            
            return Guid.Empty;
        }

        public User User()
        {
            VerifyAndLoadUser();

            return _user;
        }

        private void VerifyAndLoadUser()
        {
            if (_user != null)
            {
                return;
            }
            
            if (!IsAuthenticated())
            {
                throw new Exception("Http session is not authenticated, cannot fetch User from database");
            }
            
            var externalId = ClaimsPrincipal().Claims
                .First(c => c.Type == NameIdentifierType).Value;

            _user = _dbContext.Users.FirstOrDefault(u => u.ExternalId == externalId);

            if (_user == null)
            {
                throw new Exception($"Http session is authenticated but could not fetch User from database using ExternalId {externalId}");
            }
        }
    }
}