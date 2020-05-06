using LaDanse.Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaDanse.Core.GameData.Domain.Entities
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
