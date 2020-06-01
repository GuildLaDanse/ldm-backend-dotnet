using System;
using LaDanse.Domain.Entities.Identity;

namespace LaDanse.Domain.Entities.GameData.Sync.Profile
{
    public partial class ProfileSync : GameCharacterSource
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
