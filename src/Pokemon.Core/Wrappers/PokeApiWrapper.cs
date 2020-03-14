using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Pokemon.Core.Interfaces;

namespace Pokemon.Core.Wrappers
{
    [ExcludeFromCodeCoverage] // exclude from code coverage as it's relied on external services 
    public class PokeApiWrapper : IPokeApiWrapper
    {
        private readonly IPokemonConfiguration _pokemonConfiguration;

        public PokeApiWrapper(IPokemonConfiguration pokemonConfiguration)
        {
            _pokemonConfiguration = pokemonConfiguration;
        }

        public async Task<string> GetSpecies(string pokemonName)
        {
            if (string.IsNullOrEmpty(pokemonName))
            {
                return null;
            }

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_pokemonConfiguration.PokeApiBaseUrl}/v2/pokemon-species/{pokemonName}");
            return response.StatusCode == HttpStatusCode.NotFound ? null : await response.Content.ReadAsStringAsync();
        }
    }
}
