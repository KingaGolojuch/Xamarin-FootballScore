using Newtonsoft.Json;
using System.Collections.Generic;

namespace PROJEKT.Models.API
{
    public class FixturesDTO
    {
        [JsonProperty("fixtures")]
        public List<FixtureDTO> Fixtures { get; set; }
    }
}
