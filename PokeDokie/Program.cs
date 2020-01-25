using System;
using System.Threading.Tasks;
using PokeDokie.Services;
using PokeDokie.Utils;

namespace PokeDokie
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            var api = new PokeApi();
            var service = new PokemonService(api);
            var value = await service.GetPokemon("pikachu");

            Console.WriteLine(value.Name);
            Console.WriteLine(value.Types[0].Type.Name);
        }
    }
}
