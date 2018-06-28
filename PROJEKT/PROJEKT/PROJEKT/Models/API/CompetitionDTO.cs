using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    /// <summary> 
    /// Klasa pomocnicza do wczytywania danych z API za pomocą JSON. 
    /// Dane pojedynczego konkursu. 
    /// </summary> 
    public class CompetitionDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("league")]
        public string League { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("currentMatchday")]
        public int CurrentMatchday { get; set; }

        [JsonProperty("numberOfMatchdays")]
        public int NumberOfMatchdays { get; set; }

        [JsonProperty("numberOfTeams")]
        public int NumberOfTeams { get; set; }

        [JsonProperty("numberOfGames")]
        public int NumberOfGames { get; set; }

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }
    }
}
