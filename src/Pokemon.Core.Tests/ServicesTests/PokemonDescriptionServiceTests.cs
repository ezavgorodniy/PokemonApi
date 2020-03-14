using System.Threading.Tasks;
using Pokemon.Core.Services;
using Xunit;

namespace Pokemon.Core.Tests.ServicesTests
{
    public class PokemonDescriptionServiceTests
    {
        private readonly PokemonDescriptionService _pokemonDescriptionService;

        public PokemonDescriptionServiceTests()
        {
            _pokemonDescriptionService = new PokemonDescriptionService();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ShakespearenStyleDescriptionPokemonNameNullOrEmptyExpectNullDescription(string nullOrEmptyPokemonName)
        {
            var actualDescription = await _pokemonDescriptionService.ShakespearenStyleDescription(nullOrEmptyPokemonName);

            Assert.Null(actualDescription);
        }

        [Fact]
        public async Task ShakespearenStyleDescriptionTest()
        {
            const string expectedPokemonName = "expectedPokemonName";

            var actualDescription = await _pokemonDescriptionService.ShakespearenStyleDescription(expectedPokemonName);

            Assert.NotNull(actualDescription);
            Assert.Equal(expectedPokemonName, actualDescription.Name);
            Assert.Equal($"Description for {expectedPokemonName}", actualDescription.Description);
        }
    }
}
