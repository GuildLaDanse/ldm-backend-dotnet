using Shared = LaDanse.External.BattleNet.Abstractions.Models.Shared;
using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.GuildRoster
{
    public class GuildCharacter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("realm")]
        public Realm Realm { get; set; }
        
        [JsonProperty("level")]
        public int Level { get; set; }
        
        [JsonProperty("playable_class")]
        public Shared.PlayableClass PlayableClass { get; set; }
        
        [JsonProperty("playable_race")]
        public Shared.PlayableRace PlayableRace { get; set; }
    }
}