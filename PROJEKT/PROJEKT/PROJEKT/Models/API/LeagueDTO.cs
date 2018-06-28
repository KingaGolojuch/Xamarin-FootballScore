using Newtonsoft.Json;

namespace PROJEKT.Models.API
{
    /// <summary> 
    /// Klasa pomocnicza do wczytywania danych z API za pomocą JSON. 
    /// Dane pojedynczego wiersza w tabeli ligi. 
    /// </summary> 
    public class LeagueDTO
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("teamName")]
        public string TeamName { get; set; }

        [JsonProperty("playedGames")]
        public int PlayedGames { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("draws")]
        public int Draws { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }
    }
}
