using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokeDokie.Models;
using PokeDokie.Services;
using PokeDokieTests.Mocks;

namespace PokeDokieTests
{
    [TestClass]
    public class PokemonServiceTest
    {
        private PokemonService service;
        private readonly ApiRef mockApiRef = new ApiRef() { Name = "ground", Url = "https://pokeapi.co/api/v2/type/5/" };

        public PokemonServiceTest()
        {
            service = new PokemonService(new PokeApiMock());
        }

        [TestMethod]
        public async Task GetPokemon_HasName()
        {
            var testyPokemon = await service.GetPokemon("pikachu");
            Assert.AreEqual(testyPokemon.Name, "pikachu");
        }

        [TestMethod]
        public async Task GetPokemon_HasType()
        {
            var testyPokemon = await service.GetPokemon("pikachu");
            Assert.AreEqual(testyPokemon.Types[0].Type.Name, "electric");
            Assert.AreEqual(testyPokemon.Types[0].Type.Url, "https://pokeapi.co/api/v2/type/13/");
        }

        [TestMethod]
        public async Task GetType_HasDamageRelationships()
        {
            var testyPokemonType = await service.GetType("electric");
            Assert.IsNotNull(testyPokemonType.DamageRelations);
            Assert.AreEqual(testyPokemonType.DamageRelations.DoubleDamageFrom.Length, 1);
            Assert.AreEqual(testyPokemonType.DamageRelations.DoubleDamageTo.Length, 2);
            Assert.AreEqual(testyPokemonType.DamageRelations.HalfDamageFrom.Length, 3);
            Assert.AreEqual(testyPokemonType.DamageRelations.HalfDamageTo.Length, 3);
            Assert.AreEqual(testyPokemonType.DamageRelations.NoDamageFrom.Length, 0);
            Assert.AreEqual(testyPokemonType.DamageRelations.NoDamageTo.Length, 1);
        }


        [TestMethod]
        public async Task GetType_HasDetailsInDamangeRelationships()
        {
            var testyPokemonType = await service.GetType("electric");
            Assert.AreEqual(testyPokemonType.DamageRelations.DoubleDamageFrom[0].Name, mockApiRef.Name);
            Assert.AreEqual(testyPokemonType.DamageRelations.DoubleDamageFrom[0].Url, mockApiRef.Url);
        }

        [TestMethod]
        public void StringifyDamageRelationship_ReturnsFriendlyString()
        {
            var mockApiRefArray = new ApiRef[]
            {
                mockApiRef
            };

            var testyString = service.StringifyDamageRelationship(mockApiRefArray, "NoDamageTo");
            Assert.AreEqual(testyString, "Does not do damage to ground\n");
        }
    }
}