using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.Shared
{
    public class PlayableRace
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}