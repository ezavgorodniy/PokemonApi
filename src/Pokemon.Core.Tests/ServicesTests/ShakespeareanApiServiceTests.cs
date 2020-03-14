using System.Threading.Tasks;
using Moq;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Services;
using Xunit;

namespace Pokemon.Core.Tests.ServicesTests
{
    public class ShakespeareanApiServiceTests
    {
        private readonly Mock<IShakespeareanApiWrapper> _mockShakespeareanApiWrapper;
        private readonly ShakespeareanApiService _shakespeareanApiService;

        public ShakespeareanApiServiceTests()
        {
            _mockShakespeareanApiWrapper = new Mock<IShakespeareanApiWrapper>();

            _shakespeareanApiService = new ShakespeareanApiService(_mockShakespeareanApiWrapper.Object);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task TranslateNullOrEmptyPokemonNameExpectNull(string expectedPokemonName)
        {
            var actualDescription = await _shakespeareanApiService.Translate(expectedPokemonName);

            Assert.Null(actualDescription);
        }

        [Fact]
        public async Task TranslateNoTranslateExpectNull()
        {
            const string expectedPokemonName = "expectedPokemonName";

            _mockShakespeareanApiWrapper
                .Setup(wrapper => wrapper.Translate(expectedPokemonName))
                .Returns(Task.FromResult(null as string));

            var actualDescription = await _shakespeareanApiService.Translate(expectedPokemonName);

            Assert.Null(actualDescription);
        }

        [Fact]
        public async Task GetDescriptionExpectDescriptionFromFirstEnglishSpeciesFlavorText()
        {
            const string expectedOriginalText = "expectedOriginalText";
            const string expectedTranslation = "ExpectedTranslation";

            _mockShakespeareanApiWrapper
                .Setup(wrapper => wrapper.Translate(expectedOriginalText))
                .Returns(Task.FromResult("{ " +
                                            "\"contents\": {" +
                                                "\"translated\": \""+ expectedTranslation  + "\"" +  
                                              "}" +
                                         "}"));

            var actualDescription = await _shakespeareanApiService.Translate(expectedOriginalText);

            Assert.Equal(expectedTranslation, actualDescription);
        }
    }
}
