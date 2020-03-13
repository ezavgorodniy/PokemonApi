using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.Api.Models;

namespace Pokemon.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController
    {
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{name}")]
        public PokemonDescription Pokemon(string name)
        {
            return new PokemonDescription
            {
                Description = $"Description for {name}", 
                Name = name
            };
        }
    }
}
