using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    public class TeamsDTO
    {
        [JsonProperty("teams")]
        public List<TeamDTO> Teams { get; set; }
    }
}
