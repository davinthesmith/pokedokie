using System;
using System.Threading.Tasks;
using PokeDokie.Utils;

namespace PokeDokieTests.Mocks
{
    public class PokeApiMock : IPokeApi
    {
        public Task<string> GetPokemon(string name) {
            return Task.FromResult("{\"name\": \"pikachu\", \"types\": [ { \"slot\": 1, \"type\": { \"name\": \"electric\", \"url\": \"https://pokeapi.co/api/v2/type/13/\" } }]}");
        }
        public Task<string> GetType(string name)
        {
            return Task.FromResult("{ \"damage_relations\": { \"double_damage_from\": [ { \"name\": \"ground\", \"url\": \"https://pokeapi.co/api/v2/type/5/\" } ], \"double_damage_to\": [ { \"name\": \"flying\", \"url\": \"https://pokeapi.co/api/v2/type/3/\" }, { \"name\": \"water\", \"url\": \"https://pokeapi.co/api/v2/type/11/\" } ], \"half_damage_from\": [ { \"name\": \"flying\", \"url\": \"https://pokeapi.co/api/v2/type/3/\" }, { \"name\": \"steel\", \"url\": \"https://pokeapi.co/api/v2/type/9/\" }, { \"name\": \"electric\", \"url\": \"https://pokeapi.co/api/v2/type/13/\" } ], \"half_damage_to\": [ { \"name\": \"grass\", \"url\": \"https://pokeapi.co/api/v2/type/12/\" }, { \"name\": \"electric\", \"url\": \"https://pokeapi.co/api/v2/type/13/\" }, { \"name\": \"dragon\", \"url\": \"https://pokeapi.co/api/v2/type/16/\" } ], \"no_damage_from\": [], \"no_damage_to\": [ { \"name\": \"ground\", \"url\": \"https://pokeapi.co/api/v2/type/5/\" } ] }}"); 
        }
    }
}



