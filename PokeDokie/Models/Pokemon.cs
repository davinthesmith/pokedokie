using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeDokie.Models
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("types")]
        public TypeItem[] Types { get; set; }
    }

    public class TypeItem
    {
        [JsonProperty("type")]
        public ApiRef Type { get; set; }
    }
}
