using System;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.GameData.Sync
{
    public partial class GameCharacterSource : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
