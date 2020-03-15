using System.Threading.Tasks;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Models;

namespace Pokemon.Core.Services
{
    public class PokemonDescriptionService : IPokemonDescriptionService
    {
        private const string DescriptionCachePrefix = "DESCRIPTION_";

        private readonly ICacheService _cacheService;
        private readonly IPokeApiService _pokeApiService;
        private readonly IShakespeareanApiService _shakespeareanApiService;

        public PokemonDescriptionService(ICacheService cacheService, 
            IPokeApiService pokeApiService,
            IShakespeareanApiService shakespeareanApiService)
        {
            _cacheService = cacheService;
            _pokeApiService = pokeApiService;
            _shakespeareanApiService = shakespeareanApiService;
        }

        public async Task<PokemonDescription> ShakespearenStyleDescription(string pokemonName)
        {
            if (string.IsNullOrEmpty(pokemonName))
            {
                return null;
            }

            var cacheKey = DescriptionCachePrefix + pokemonName;
            var cachedDescription = _cacheService.GetValue(cacheKey);
            if (cachedDescription != null)
            {
                return new PokemonDescription
                {
                    Description = cachedDescription,
                    Name = pokemonName
                };
            }

            var pokemonDescription = await _pokeApiService.GetDescription(pokemonName);
            if (pokemonDescription == null)
            {
                return null;
            }

            var translatedPokemonDescription = await _shakespeareanApiService.Translate(pokemonDescription);
            _cacheService.SetValue(cacheKey, translatedPokemonDescription);
            return new PokemonDescription
            {
                Description = translatedPokemonDescription,
                Name = pokemonName
            };
        }
    }
}
