﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    /// <summary> 
    /// Klasa pomocnicza do wczytywania danych z API za pomocą JSON. 
    /// Dane pojedynczego meczu. 
    /// </summary> 
    public class FixtureDTO
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("homeTeamName")]
        public string HomeTeamName { get; set; }

        [JsonProperty("awayTeamName")]
        public string AwayTeamName { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("result")]
        public FixtureResultDTO Result { get; set; }
    }
}
