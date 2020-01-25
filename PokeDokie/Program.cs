using System;
using System.Threading.Tasks;
using PokeDokie.Services;
using PokeDokie.Utils;
using Unity;
using dotenv.net;

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
            var container = new UnityContainer();
            container.RegisterType<IPokeApi, PokeApi>();
            var service = container.Resolve<PokemonService>();

            Console.WriteLine("Welcome to PokeDokie!\n\n");

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
    }
}
