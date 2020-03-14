using System.Threading.Tasks;
using Pokemon.Core.Models;

namespace Pokemon.Core.Interfaces
{
    public interface IPokemonDescriptionService
    {
        Task<PokemonDescription> ShakespearenStyleDescription(string pokemonName);
    }
}
