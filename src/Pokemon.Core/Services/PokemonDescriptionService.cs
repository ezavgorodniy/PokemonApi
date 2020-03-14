using System.Threading.Tasks;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Models;

namespace Pokemon.Core.Services
{
    public class PokemonDescriptionService : IPokemonDescriptionService
    {
        private readonly IPokeApiService _pokeApiService;
        private readonly IShakespeareanApiService _shakespeareanApiService;

        public PokemonDescriptionService(IPokeApiService pokeApiService,
            IShakespeareanApiService shakespeareanApiService)
        {
            _pokeApiService = pokeApiService;
            _shakespeareanApiService = shakespeareanApiService;
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

            var translatedPokemonDescription = await _shakespeareanApiService.Translate(pokemonDescription);
            return new PokemonDescription
            {
                Description = translatedPokemonDescription,
                Name = pokemonName
            };
        }
    }
}
