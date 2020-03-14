using System.Threading.Tasks;

namespace Pokemon.Core.Interfaces
{
    public interface IPokeApiWrapper
    {
        Task<string> GetSpecies(string pokemonName);
    }
}
