using System;
using Microsoft.Extensions.Configuration;
using Moq;
using Pokemon.Core.Configuration;
using Xunit;

namespace Pokemon.Core.Tests.ConfigurationTests
{
    public class PokemonConfigurationTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly PokemonConfiguration _pokemonConfiguration;

        public PokemonConfigurationTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();

            _pokemonConfiguration = new PokemonConfiguration(_mockConfiguration.Object);
        }

        [Fact]
        public void PokeApiBaseUrlTest()
        {
            RunConfigurationTest(nameof(PokemonConfiguration.PokeApiBaseUrl),
                () => _pokemonConfiguration.PokeApiBaseUrl);
        }

        [Fact]
        public void ShakespeareanApiUrlTest()
        {
            RunConfigurationTest(nameof(PokemonConfiguration.ShakespeareanApiUrl),
                () => _pokemonConfiguration.ShakespeareanApiUrl);
        }

        [Fact]
        public void ShakespeareanApiSecretTest()
        {
            RunConfigurationTest(nameof(PokemonConfiguration.ShakespeareanApiSecret), 
                () => _pokemonConfiguration.ShakespeareanApiSecret);
        }

        private void RunConfigurationTest(string key, Func<string> pokemonConfigurationGetter)
        {
            const string expectedUrl = "http://dummy.url";

            _mockConfiguration
                .SetupGet(configuration => configuration[key])
                .Returns(expectedUrl);

            var actualUrl = pokemonConfigurationGetter();

            Assert.Equal(expectedUrl, actualUrl);
        }
    }
}
