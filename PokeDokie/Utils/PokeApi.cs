using System;
using PokeDokie.Models;

namespace PokeDokie.Utils
{
    public interface IPokeApi
    {
        public Pokemon GetPokemon(string name);
        public PokemonType GetType(string name);
    }

    public class PokeApi : IPokeApi
    {
        public PokeApi()
        {
        }

        public Pokemon GetPokemon(string name)
        {
            throw new NotImplementedException();
            return new Pokemon();
        }
        public PokemonType GetType(string name)
        {
            throw new NotImplementedException();
            return new PokemonType();
        }
    }
}
