using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    /// <summary>
    /// Klasa pomocnicza do wczytywania danych z API za pomocą JSON.
    /// Lista wierszy w tabeli ligi.
    /// </summary>
    public class LeaguesDTO
    {
        [JsonProperty("standing")]
        public List<LeagueDTO> League { get; set; }
    }
}
