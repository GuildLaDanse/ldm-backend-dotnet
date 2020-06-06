using LaDanse.External.BattleNet.Abstractions.Models.Shared;
using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.GuildInfo
{
    public class Guild
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }
        
        [JsonProperty("faction")]
        public Faction Faction { get; set; }
        
        [JsonProperty("realm")]
        public Realm Realm { get; set; }
    }
}