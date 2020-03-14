using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Core.Configuration;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Services;

namespace Pokemon.Core
{
    // TODO: cover as soon as IServiceCollection will be properly mocked
    [ExcludeFromCodeCoverage] 
    public static class RegisterServices
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPokemonConfiguration, PokemonConfiguration>();
            services.AddTransient<IPokemonDescriptionService, PokemonDescriptionService>();
        }
    }
}
