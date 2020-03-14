using System.Threading.Tasks;
using Moq;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Services;
using Xunit;

namespace Pokemon.Core.Tests.ServicesTests
{
    public class PokeApiServiceTests
    {
        private readonly Mock<IPokeApiWrapper> _mockPokeApiWrapper;
        private readonly PokeApiService _pokeApiService;

        public PokeApiServiceTests()
        {
            _mockPokeApiWrapper = new Mock<IPokeApiWrapper>();

            _pokeApiService = new PokeApiService(_mockPokeApiWrapper.Object);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task GetDescriptionNullOrEmptyPokemonNameExpectNull(string expectedPokemonName)
        {
            var actualDescription = await _pokeApiService.GetDescription(expectedPokemonName);

            Assert.Null(actualDescription);
        }

        [Fact]
        public async Task GetDescriptionNoSpeciesExpectNull()
        {
            const string expectedPokemonName = "expectedPokemonName";

            _mockPokeApiWrapper
                .Setup(wrapper => wrapper.GetSpecies(expectedPokemonName))
                .Returns(Task.FromResult(null as string));

            var actualDescription = await _pokeApiService.GetDescription(expectedPokemonName);

            Assert.Null(actualDescription);
        }

        [Fact]
        public async Task GetDescriptionNoEnglishSpeciesExpectNull()
        {
            const string expectedPokemonName = "expectedPokemonName";

            _mockPokeApiWrapper
                .Setup(wrapper => wrapper.GetSpecies(expectedPokemonName))
                .Returns(Task.FromResult("{ " +
                                            "\"flavor_text_entries\": [ " +
                                              "{" +
                                                "\"flavor_text\": \"Покемон летает по небу в поисках могущественных противников.\", " +
                                                "\"language\": {" +
                                                  "\"name\": \"ru\"" +
                                                "}" +
                                              "}" +
                                            "]" +
                                         "}"));

            var actualDescription = await _pokeApiService.GetDescription(expectedPokemonName);

            Assert.Null(actualDescription);
        }


        [Fact]
        public async Task GetDescriptionExpectDescriptionFromFirstEnglishSpeciesFlavorText()
        {
            const string expectedEnglishLanguageName = "en";
            const string expectedPokemonName = "expectedPokemonName";
            const string expectedFlavorText = "Charizard flies around the sky in search of powerful opponents.";

            _mockPokeApiWrapper
                .Setup(wrapper => wrapper.GetSpecies(expectedPokemonName))
                .Returns(Task.FromResult("{ " +
                                            "\"flavor_text_entries\": [ " +
                                              "{" +
                                                "\"flavor_text\": \"Покемон летает по небу в поисках могущественных противников.\", " +
                                                "\"language\": {" +
                                                  "\"name\": \"ru\"" +
                                                "}" +
                                              "}," +
                                              "{" +
                                                "\"flavor_text\": \"" + expectedFlavorText + "\", " +
                                                "\"language\": {" +
                                                  "\"name\": \"" + expectedEnglishLanguageName + "\"" +
                                                "}" +
                                              "}" +
                                            "]" +
                                         "}"));

            var actualDescription = await _pokeApiService.GetDescription(expectedPokemonName);

            Assert.Equal(expectedFlavorText, actualDescription);
        }
    }
}
