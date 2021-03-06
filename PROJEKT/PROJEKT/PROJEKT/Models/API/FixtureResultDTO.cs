﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    /// <summary> 
    /// Klasa pomocnicza do wczytywania danych z API za pomocą JSON. 
    /// Dane wyniku meczu danego zespołu. 
    /// </summary> 
    public class FixtureResultDTO
    {
        [JsonProperty("goalsHomeTeam")]
        public int GoalsHomeTeam { get; set; }

        [JsonProperty("goalsAwayTeam")]
        public int GoalsAwayTeam { get; set; }
    }
}
