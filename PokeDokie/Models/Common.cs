using Newtonsoft.Json;

namespace PokeDokie.Models
{
    public class ApiRef
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
