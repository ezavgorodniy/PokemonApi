using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Models;

namespace Pokemon.Core.Services
{
    public class PokeApiService : IPokeApiService
    {
        private readonly IPokeApiWrapper _pokeApiWrapper;

        public PokeApiService(IPokeApiWrapper pokeApiWrapper)
        {
            _pokeApiWrapper = pokeApiWrapper;
        }

        public async Task<string> GetDescription(string pokemonName)
        {
            if (string.IsNullOrEmpty(pokemonName))
            {
                return null;
            }

            var pokemonDescription = await _pokeApiWrapper.GetSpecies(pokemonName);
            if (pokemonDescription == null)
            {
                return null;
            }

            // TODO: check if received answer is valid Json 
            var jObject = JObject.Parse(pokemonDescription);
            var flavorTextEntriesJson = (JArray) jObject["flavor_text_entries"];

            var flavorTextEntries = flavorTextEntriesJson.ToObject<List<FlavorTextEntry>>();

            var firstEnglishEntry = flavorTextEntries.FirstOrDefault(entry => entry.Language.Name == "en");
            return firstEnglishEntry?.FlavorText;
        }
    }
}
