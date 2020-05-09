using System;

namespace LaDanse.Core.GameData.Models
{
    public class RealmDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public int GameId { get; set; }
    }
}