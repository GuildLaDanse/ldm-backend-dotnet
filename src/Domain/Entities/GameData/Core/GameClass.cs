using System;
using LaDanse.Domain.Shared;

namespace LaDanse.Domain.Entities.GameData.Core
{
    public partial class GameClass : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
    }
}
