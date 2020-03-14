using System.Threading.Tasks;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Models;

namespace Pokemon.Core.Services
{
    public class PokemonDescriptionService : IPokemonDescriptionService
    {
        public Task<PokemonDescription> ShakespearenStyleDescription(string pokemonName)
        {
            if (string.IsNullOrEmpty(pokemonName))
            {
                return Task.FromResult(null as PokemonDescription);
            }

            return Task.FromResult(new PokemonDescription
            {
                Description = $"Description for {pokemonName}",
                Name = pokemonName
            });
        }
    }
}
