using System.Threading.Tasks;

namespace Pokemon.Core.Interfaces
{
    public interface IShakespeareanApiWrapper
    {
        Task<string> Translate(string originalText);
    }
}
