using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    /// <summary>
    /// Klasa pomocnicza do wczytywania danych z API za pomocą JSON.
    /// Lista meczy.
    /// </summary>
    public class FixturesDTO
    {
        [JsonProperty("fixtures")]
        public List<FixtureDTO> Fixtures { get; set; }
    }
}
