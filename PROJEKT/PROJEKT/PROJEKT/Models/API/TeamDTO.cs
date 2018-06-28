using Newtonsoft.Json;

namespace PROJEKT.Models.API
{
    public class TeamDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
