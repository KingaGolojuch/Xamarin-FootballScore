using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    /// <summary>
    /// Klasa pomocnicza do wczytywania danych z API za pomocą JSON.
    /// Lista drużyn.
    /// </summary>
    public class TeamsDTO
    {
        [JsonProperty("teams")]
        public List<TeamDTO> Teams { get; set; }
    }
}
