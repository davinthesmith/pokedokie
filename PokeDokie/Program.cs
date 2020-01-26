using System;
using System.Threading.Tasks;
using PokeDokie.Services;
using PokeDokie.Utils;
using Unity;
using dotenv.net;
using System.Net.Http;

namespace PokeDokie
{
    class Program
    {
        static void Main()
        {
            DotEnv.Config();
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Welcome to PokeDokie!\n\n");

            var service = InitService();

            while (true)
            {
                Console.WriteLine("Which pokemon do you want to use?");
                Console.WriteLine("(Press Enter to quit)\n");
                var pokemonName = Console.ReadLine();

                if (pokemonName == "")
                {
                    break;
                }

                var report = await service.GetDamageRelationsReport(pokemonName);
                Console.WriteLine(report);
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
            }
        }

        static PokemonService InitService()
        {
            // Register IoC Container
            var container = new UnityContainer();
            container.RegisterFactory<HttpClient>(x => new HttpClient
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("API_URL"))
            });
            container.RegisterType<IPokeApi, PokeApi>();

            // Return instance of service
            return container.Resolve<PokemonService>();
        }
    }
}
