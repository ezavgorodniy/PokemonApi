using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Pokemon.Core.Interfaces;

namespace Pokemon.Core.Services
{
    public class ShakespeareanApiService : IShakespeareanApiService
    {
        private readonly IShakespeareanApiWrapper _shakespeareanApiWrapper;

        public ShakespeareanApiService(IShakespeareanApiWrapper shakespeareanApiWrapper)
        {
            _shakespeareanApiWrapper = shakespeareanApiWrapper;
        }

        public async Task<string> Translate(string originalText)
        {
            if (string.IsNullOrEmpty(originalText))
            {
                return null;
            }

            var translatedTextJson = await _shakespeareanApiWrapper.Translate(originalText);
            if (translatedTextJson == null)
            {
                return null;
            }

            // TODO: check if received answer is valid Json 
            var jObject = JObject.Parse(translatedTextJson);
            return jObject["contents"]["translated"].Value<string>();
        }
    }
}
