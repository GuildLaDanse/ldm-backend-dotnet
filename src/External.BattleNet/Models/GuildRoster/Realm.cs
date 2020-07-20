using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.GuildRoster
{
    public class Realm
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("slug")] public string Slug { get; set; }
    }
}