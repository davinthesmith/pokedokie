using System;
using System.Threading.Tasks;
using PokeDokie.Models;
using PokeDokie.Utils;
using Newtonsoft.Json;

namespace PokeDokie.Services
{
    public class PokemonService
    {
        private readonly IPokeApi _api;

        public PokemonService(IPokeApi Api)
        {
            _api = Api;
        }

        public async Task<Pokemon> GetPokemon(string name)
        {
            var jsonResponse = await _api.GetPokemon(name);
            return JsonConvert.DeserializeObject<Pokemon>(jsonResponse);
        }
    }
}
