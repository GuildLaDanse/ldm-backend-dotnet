using System;
using LaDanse.Domain.Entities.Shared;

namespace LaDanse.Domain.Entities.GameData.Core
{
    public partial class GameRealm : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string GameSlug { get; set; }
        public int GameId { get; set; }
    }
}
