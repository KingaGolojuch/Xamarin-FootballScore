using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    public class LeaguesDTO
    {
        [JsonProperty("standing")]
        public List<LeagueDTO> League { get; set; }
    }
}
