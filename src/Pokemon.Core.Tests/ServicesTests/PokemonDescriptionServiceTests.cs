using System.Threading.Tasks;
using Moq;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Services;
using Xunit;

namespace Pokemon.Core.Tests.ServicesTests
{
    public class PokemonDescriptionServiceTests
    {
        private readonly Mock<IPokeApiService> _mockPokeApiService;
        private readonly PokemonDescriptionService _pokemonDescriptionService;

        public PokemonDescriptionServiceTests()
        {
            _mockPokeApiService = new Mock<IPokeApiService>();
            _pokemonDescriptionService = new PokemonDescriptionService(_mockPokeApiService.Object);
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
        public async Task ShakespearenStyleDescriptionPokemonDescriptionNullExpectNullDescription()
        {
            const string expectedPokemonName = "expectedPokemonName";

            _mockPokeApiService
                .Setup(service => service.GetDescription(expectedPokemonName))
                .Returns(Task.FromResult(null as string));

            var actualDescription = await _pokemonDescriptionService.ShakespearenStyleDescription(expectedPokemonName);

            Assert.Null(actualDescription);
        }

        [Fact]
        public async Task ShakespearenStyleDescriptionTest()
        {
            const string expectedPokemonName = "expectedPokemonName";
            const string expectedDescription = "expectedDescription";

            _mockPokeApiService
                .Setup(service => service.GetDescription(expectedPokemonName))
                .Returns(Task.FromResult(expectedDescription));
            
            var actualDescription = await _pokemonDescriptionService.ShakespearenStyleDescription(expectedPokemonName);

            Assert.NotNull(actualDescription);
            Assert.Equal(expectedPokemonName, actualDescription.Name);
            Assert.Equal(expectedDescription, actualDescription.Description);
        }
    }
}
