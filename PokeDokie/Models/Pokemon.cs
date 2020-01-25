using Newtonsoft.Json;

namespace PokeDokie.Models
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("types")]
        public TypeArray[] Types { get; set; }
    }

    public class TypeArray
    {
        [JsonProperty("type")]
        public ApiRef[] Type { get; set; }
    }
}
