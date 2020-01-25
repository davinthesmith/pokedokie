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
            var report = await service.GetDamageRelationsReport("pikachu");
            Console.WriteLine(report);
        }
    }
}
