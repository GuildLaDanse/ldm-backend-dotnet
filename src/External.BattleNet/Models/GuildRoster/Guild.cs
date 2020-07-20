using LaDanse.External.BattleNet.Abstractions.Models.Shared;
using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.GuildRoster
{
    public class Guild
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("faction")] public Faction Faction { get; set; }

        [JsonProperty("realm")] public Realm Realm { get; set; }
    }
}