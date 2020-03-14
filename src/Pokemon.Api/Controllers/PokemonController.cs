using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.Core.Interfaces;

namespace Pokemon.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController
    {
        private readonly IPokemonDescriptionService _pokemonDescriptionService;
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger, IPokemonDescriptionService pokemonDescriptionService)
        {
            _logger = logger;
            _pokemonDescriptionService = pokemonDescriptionService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> Pokemon(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new NotFoundResult();
            }

            var pokemonDescription = await _pokemonDescriptionService.ShakespearenStyleDescription(name);
            return pokemonDescription != null
                ? (ActionResult) new OkObjectResult(pokemonDescription)
                : new NotFoundResult();
        }
    }
}
