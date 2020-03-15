using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Pokemon.FunctionalTests.Base;
using Xunit;

namespace Pokemon.FunctionalTests
{
    public class PokemonTests : BaseIntegrationTests
    {
        [Fact]
        public async Task CharizardExpectReturnDescription()
        {
            const string knownPokemonName = "charizard";
            var response = await Client.GetAsync(new Uri($"{ApiUrl.Trim('/')}/pokemon/charizard"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();

            var parsedJson = JObject.Parse(result);
            Assert.Equal(knownPokemonName, parsedJson["name"].Value<string>());

            const string expecetdDescription =
                "Charizard flies 'round the sky in search of powerful opponents.\\nit breathes fire of such most wondrous heat yond 't melts aught.\\nhowever,  't nev'r turns its fiery breath on any opponent\\nweaker than itself.";
            Assert.Equal(expecetdDescription, parsedJson["description"].Value<string>()); // TODO: add description check 
        }

        [Fact]
        public async Task EmptyExpectReturnNotFound()
        {
            var response = await Client.GetAsync(new Uri($"{ApiUrl.Trim('/')}/pokemon/"));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task NotKnownExpectReturnNotFound()
        {
            var response = await Client.GetAsync(new Uri($"{ApiUrl.Trim('/')}/pokemon/invalidPokemonName"));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
