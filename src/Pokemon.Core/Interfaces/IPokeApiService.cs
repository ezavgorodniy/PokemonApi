using System.Threading.Tasks;

namespace Pokemon.Core.Interfaces
{
    public interface IPokeApiService
    {
        Task<string> GetDescription(string pokemonName);
    }
}
