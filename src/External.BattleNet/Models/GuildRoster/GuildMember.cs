using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.GuildRoster
{
    public class GuildMember
    {
        [JsonProperty("character")]
        public GuildCharacter Character { get; set; }
        
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}