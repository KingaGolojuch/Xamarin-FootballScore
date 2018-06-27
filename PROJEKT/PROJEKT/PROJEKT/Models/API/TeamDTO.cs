using Newtonsoft.Json;

namespace PROJEKT.Models.API
{
    /// <summary>
    /// Klasa pomocnicza do wczytywania danych z API za pomocą JSON.
    /// Dane pojedynczego zespołu.
    /// </summary>
    public class TeamDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
