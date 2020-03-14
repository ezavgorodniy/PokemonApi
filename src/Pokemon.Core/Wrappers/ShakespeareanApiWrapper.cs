using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Pokemon.Core.Interfaces;

namespace Pokemon.Core.Wrappers
{
    [ExcludeFromCodeCoverage] // exclude from code coverage as it's relied on external services 
    public class ShakespeareanApiWrapper : IShakespeareanApiWrapper
    {
        private const string ApiSecretHeaderKey = "X-Funtranslations-Api-Secret";

        private readonly IPokemonConfiguration _pokemonConfiguration;

        public ShakespeareanApiWrapper(IPokemonConfiguration pokemonConfiguration)
        {
            _pokemonConfiguration = pokemonConfiguration;
        }

        public async Task<string> Translate(string originalText)
        {
            if (string.IsNullOrEmpty(originalText))
            {
                return null;
            }

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(ApiSecretHeaderKey, _pokemonConfiguration.ShakespeareanApiSecret);


            var builder = new UriBuilder(_pokemonConfiguration.ShakespeareanApiUrl)
            {
                Query = $"text={ApplyWorkaroundForNextLine(originalText)}"
            };

            var response = await httpClient.GetAsync(builder.Uri);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            return RevertWorkaroundForNextLine(responseString);
        }

        /// <summary>
        /// Required for workaround because of returning 404 from API when \n is presented
        /// </summary>
        /// <param name="s"></param>
        /// <returns>replace \n with \\n</returns>
        private static string ApplyWorkaroundForNextLine(string s)
        {
            return s.Replace("\n", "\\n");
        }

        /// <summary>
        /// Required for workaround because of returning 404 from API when \n is presented
        /// </summary>
        /// <param name="s"></param>
        /// <returns>replace \n with \\n</returns>
        private static string RevertWorkaroundForNextLine(string s)
        {
            return s.Replace("\\\\n", "\\n");
        }
    }
}
