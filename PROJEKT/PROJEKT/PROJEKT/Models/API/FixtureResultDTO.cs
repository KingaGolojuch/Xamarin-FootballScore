using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    public class FixtureResultDTO
    {
        [JsonProperty("goalsHomeTeam")]
        public int GoalsHomeTeam { get; set; }

        [JsonProperty("goalsAwayTeam")]
        public int GoalsAwayTeam { get; set; }
    }
}
