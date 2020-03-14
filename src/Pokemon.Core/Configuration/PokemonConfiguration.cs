using Microsoft.Extensions.Configuration;
using Pokemon.Core.Interfaces;

namespace Pokemon.Core.Configuration
{
    public class PokemonConfiguration : IPokemonConfiguration
    {
        private readonly IConfiguration _configuration;

        public PokemonConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ShakespeareanApiUrl => _configuration["ShakespeareanApiUrl"];

        public string PokeApiBaseUrl => _configuration["PokeApiBaseUrl"];
    }
}
