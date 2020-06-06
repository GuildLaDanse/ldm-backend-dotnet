using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.Shared
{
    public class Realm
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}