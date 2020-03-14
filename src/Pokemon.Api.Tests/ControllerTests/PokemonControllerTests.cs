using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Pokemon.Api.Controllers;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Models;
using Xunit;

namespace Pokemon.Api.Tests.ControllerTests
{
    public class PokemonControllerTests
    {
        private readonly Mock<IPokemonDescriptionService> _mockPokemonDescriptionService;
        private readonly PokemonController _pokemonController;

        public PokemonControllerTests()
        {
            _mockPokemonDescriptionService = new Mock<IPokemonDescriptionService>();
            var mockLogger = new Mock<ILogger<PokemonController>>();

            _pokemonController = new PokemonController(mockLogger.Object, _mockPokemonDescriptionService.Object);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task PokemonNullOrEmptyNameExpectNotFoundRequestRequest(string emptyPokemonName)
        {
            var actionResult = await _pokemonController.Pokemon(emptyPokemonName);

            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task PokemonNullFromServiceExpectNotFoundResult()
        {
            const string expectedPokemonName = "expectedPokemonName";
            _mockPokemonDescriptionService.Setup(service => service.ShakespearenStyleDescription(expectedPokemonName))
                .Returns(Task.FromResult(null as PokemonDescription));

            var actionResult = await _pokemonController.Pokemon(expectedPokemonName);

            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task PokemonExpectOkObjectResultWithObjectFromService()
        {
            var expectedPokemonDescription = new PokemonDescription(); 

            const string expectedPokemonName = "expectedPokemonName";
            _mockPokemonDescriptionService.Setup(service => service.ShakespearenStyleDescription(expectedPokemonName))
                .Returns(Task.FromResult(expectedPokemonDescription));

            var actionResult = await _pokemonController.Pokemon(expectedPokemonName);

            Assert.IsType<OkObjectResult>(actionResult);

            var okObjectResult = (OkObjectResult) actionResult;
            Assert.Equal(expectedPokemonDescription, okObjectResult.Value);
        }
    }
}
