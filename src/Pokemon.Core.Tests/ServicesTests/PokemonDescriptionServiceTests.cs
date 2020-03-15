using System.Threading.Tasks;
using Moq;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Services;
using Xunit;

namespace Pokemon.Core.Tests.ServicesTests
{
    public class PokemonDescriptionServiceTests
    {
        private readonly Mock<ICacheService> _mockCacheService;
        private readonly Mock<IPokeApiService> _mockPokeApiService;
        private readonly Mock<IShakespeareanApiService> _mockShakespeareanApiService;
        private readonly PokemonDescriptionService _pokemonDescriptionService;

        public PokemonDescriptionServiceTests()
        {
            _mockCacheService = new Mock<ICacheService>();
            _mockPokeApiService = new Mock<IPokeApiService>();
            _mockShakespeareanApiService = new Mock<IShakespeareanApiService>();

            _pokemonDescriptionService = new PokemonDescriptionService(_mockCacheService.Object,
                _mockPokeApiService.Object, _mockShakespeareanApiService.Object);
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
        public async Task ShakespearenStyleDescriptionTestExpectShakespearenApiReturnResult()
        {
            const string expectedPokemonName = "expectedPokemonName";
            const string expectedDescription = "expectedDescription";

            _mockPokeApiService
                .Setup(service => service.GetDescription(expectedPokemonName))
                .Returns(Task.FromResult(expectedDescription));

            const string expectedTranslation = "expectedTranslation";
            _mockShakespeareanApiService
                .Setup(service => service.Translate(expectedDescription))
                .Returns(Task.FromResult(expectedTranslation));
;            
            var actualDescription = await _pokemonDescriptionService.ShakespearenStyleDescription(expectedPokemonName);

            Assert.NotNull(actualDescription);
            Assert.Equal(expectedPokemonName, actualDescription.Name);
            Assert.Equal(expectedTranslation, actualDescription.Description);

            const string expectedCacheKey = "DESCRIPTION_" + expectedPokemonName;
            _mockCacheService.Verify(service => service.SetValue(expectedCacheKey, expectedTranslation), Times.Once);
        }

        [Fact]
        public async Task ShakespearenStyleDescriptionCachedValueNotNullExpectCachedValue()
        {
            const string expectedPokemonName = "expectedPokemonName";
            const string expectedCachedDescription = "expectedCachedDescription";
            const string expectedCacheKey = "DESCRIPTION_" + expectedPokemonName;

            _mockCacheService
                .Setup(service => service.GetValue(expectedCacheKey))
                .Returns(expectedCachedDescription);

            var actualDescription = await _pokemonDescriptionService.ShakespearenStyleDescription(expectedPokemonName);

            Assert.NotNull(actualDescription);
            Assert.Equal(expectedPokemonName, actualDescription.Name);
            Assert.Equal(expectedCachedDescription, actualDescription.Description);
        }
    }
}
