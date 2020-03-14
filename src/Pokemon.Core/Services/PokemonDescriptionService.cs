using System.Threading.Tasks;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Models;

namespace Pokemon.Core.Services
{
    public class PokemonDescriptionService : IPokemonDescriptionService
    {
        private readonly IPokeApiService _pokeApiService;

        public PokemonDescriptionService(IPokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        public async Task<PokemonDescription> ShakespearenStyleDescription(string pokemonName)
        {
            if (string.IsNullOrEmpty(pokemonName))
            {
                return null;
            }

            var pokemonDescription = await _pokeApiService.GetDescription(pokemonName);
            if (pokemonDescription == null)
            {
                return null;
            }

            return new PokemonDescription
            {
                Description = pokemonDescription,
                Name = pokemonName
            };
        }
    }
}
