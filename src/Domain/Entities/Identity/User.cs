using System;
using LaDanse.Domain.Entities.Shared;
using Microsoft.AspNetCore.Identity;

namespace LaDanse.Domain.Entities.Identity
{
    public partial class User : IdentityUser<Guid>, IBaseEntity<Guid>
    {
        public string DisplayName { get; set; }
        public DateTime? LastLogin { get; set; }

        public string PasswordSalt { get; set; }
    }
}
