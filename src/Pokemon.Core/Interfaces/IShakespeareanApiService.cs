using System.Threading.Tasks;

namespace Pokemon.Core.Interfaces
{
    public interface IShakespeareanApiService
    {
        Task<string> Translate(string originalText);
    }
}
