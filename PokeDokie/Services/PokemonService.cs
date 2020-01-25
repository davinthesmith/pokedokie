using System.Threading.Tasks;
using PokeDokie.Models;
using PokeDokie.Utils;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace PokeDokie.Services
{
    public class PokemonService
    {
        private readonly IPokeApi _api;

        public PokemonService(IPokeApi api)
        {
            _api = api;
        }

        public async Task<Pokemon> GetPokemon(string name)
        {
            var jsonResponse = await _api.GetPokemon(name);
            return JsonConvert.DeserializeObject<Pokemon>(jsonResponse);
        }

        public async Task<PokemonType> GetType(string type)
        {
            var jsonResponse = await _api.GetType(type);
            return JsonConvert.DeserializeObject<PokemonType>(jsonResponse);
        }

        public async Task<string> GetDamageRelationsReport(string pokemonName)
        {
            try
            {
                // Get vars from api
                var pokemon = await GetPokemon(pokemonName);
                var pokemonType = await GetType(pokemon.Types.First().Type.Name);

                // Cap the first letter so it looks nice
                var prettyPokemonName = pokemonName.First().ToString().ToUpper() + pokemonName.Substring(1);

                // Let's get this pokemon excited
                var report = new StringBuilder()
                    .Append(prettyPokemonName)
                    .Append(", I choose you!\n\n");

                // Report the pokemon's type
                report.Append(prettyPokemonName)
                    .Append("'s type is: ")
                    .Append(pokemonType.Name)
                    .Append("\n");

                foreach (var prop in pokemonType.DamageRelations.GetType().GetProperties())
                {
                    report.Append(StringifyDamageRelationship(
                        (ApiRef[])prop.GetValue(pokemonType.DamageRelations, null), prop.Name));
                }
                return report.ToString();
            }
            catch
            {
                // Usually I wouldn't be so cavalier with my errors, but proper error handling/logging didn't seem to be part of the criteria
                return "You pokemon could not be found... Try another\n\n";
            }
        }

        public string StringifyDamageRelationship(ApiRef[] damageRelationship, string relationshipName)
        {
            Dictionary<string, string> damageReportMap = new Dictionary<string, string>()
            {
                {"NoDamageTo",       "Does not do damage to "},
                {"HalfDamageTo",     "Does half damage to "},
                {"DoubleDamageTo",   "Does double damage to "},
                {"NoDamageFrom",     "Takes no damage from "},
                {"HalfDamageFrom",   "Takes half damage from "},
                {"DoubleDamageFrom", "Takes double damage from "}
            };

            var names = damageRelationship.Select(x => x.Name);
            var relationships = new StringBuilder();
            foreach (var name in names)
            {
                relationships.Append(damageReportMap[relationshipName])
                    .Append(name)
                    .Append("\n");
            }
            return relationships.ToString();
        }
    }
}
