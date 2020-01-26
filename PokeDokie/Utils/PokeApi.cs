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
        private static HttpClient _client;

        public PokeApi(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetPokemon(string name)
        {
            var response = await _client.GetAsync($"pokemon/{name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetType(string name)
        {
            var response = await _client.GetAsync($"type/{name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
