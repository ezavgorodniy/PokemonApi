using Newtonsoft.Json;

namespace Pokemon.Core.Models
{
    internal class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        public PokeApiReference Language { get; set; }
        
        // usually have also PokeApiReference Version property (not required for current Api purposes)
    }
}
