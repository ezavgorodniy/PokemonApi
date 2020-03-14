using Microsoft.Extensions.DependencyInjection;
using Pokemon.Core.Configuration;
using Pokemon.Core.Interfaces;

namespace Pokemon.Core
{
    public static class RegisterServices
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPokemonConfiguration, PokemonConfiguration>();
        }
    }
}
