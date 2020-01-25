using Newtonsoft.Json;

namespace PokeDokie.Models
{
    public class PokemonType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("damage_relations")]
        public DamageRelations DamageRelations { get; set; }
    }

    public class DamageRelations
    {
        [JsonProperty("no_damage_to")]
        public ApiRef[] NoDamageTo { get; set; }

        [JsonProperty("half_damage_to")]
        public ApiRef[] HalfDamageTo { get; set; }

        [JsonProperty("double_damage_to")]
        public ApiRef[] DoubleDamageTo { get; set; }

        [JsonProperty("no_damage_from")]
        public ApiRef[] NoDamageFrom { get; set; }

        [JsonProperty("half_damage_from")]
        public ApiRef[] HalfDamageFrom { get; set; }

        [JsonProperty("double_damage_from")]
        public ApiRef[] DoubleDamageFrom { get; set; }
    }
}
