using System.Collections.Generic;
using Newtonsoft.Json;

namespace LaDanse.External.BattleNet.Abstractions.Models.GuildRoster
{
    public class Roster
    {
        [JsonProperty("guild")] public Guild Guild { get; set; }

        [JsonProperty("members")] public IEnumerable<Member> Members { get; set; }
    }
}