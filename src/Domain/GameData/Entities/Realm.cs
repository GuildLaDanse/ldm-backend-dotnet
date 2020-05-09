using System;
using LaDanse.Domain.Common;

namespace LaDanse.Domain.GameData.Entities
{
    public class Realm : BaseEntity<Guid>
    {
        public Realm()
        {
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }

        public int GameId { get; set; }
    }
}
