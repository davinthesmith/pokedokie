using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PokeDokie.Utils
{
    public interface IPokeApi
    {
        public Task<string> GetPokemon(string name);
        public Task<string> GetType(string name);
    }

    public class PokeApi : IPokeApi
    {
        private static HttpClient client;

        public PokeApi()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://pokeapi.co/api/v2/")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetPokemon(string name)
        {
            var response = await client.GetAsync($"pokemon/{name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetType(string name)
        {
            var response = await client.GetAsync($"type/{name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
