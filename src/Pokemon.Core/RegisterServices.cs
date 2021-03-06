﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Core.Configuration;
using Pokemon.Core.Interfaces;
using Pokemon.Core.Services;
using Pokemon.Core.Wrappers;

namespace Pokemon.Core
{
    // TODO: cover as soon as IServiceCollection will be properly mocked
    [ExcludeFromCodeCoverage] 
    public static class RegisterServices
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IShakespeareanApiWrapper, ShakespeareanApiWrapper>();
            services.AddTransient<IPokeApiWrapper, PokeApiWrapper>();
            services.AddTransient<IShakespeareanApiService, ShakespeareanApiService>();
            services.AddTransient<IPokeApiService, PokeApiService>();
            services.AddTransient<ICacheService, DefaultCacheService>();

            services.AddTransient<IPokemonConfiguration, PokemonConfiguration>();

            services.AddTransient<IPokemonDescriptionService, PokemonDescriptionService>();
        }
    }
}
