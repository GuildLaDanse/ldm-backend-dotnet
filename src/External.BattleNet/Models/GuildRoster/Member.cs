using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.GuildRoster
{
    public class Member
    {
        [JsonProperty("character")]
        public Character Character { get; set; }
        
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}