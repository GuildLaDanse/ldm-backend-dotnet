using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.Shared
{
    public class Faction
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}