using Microsoft.Extensions.DependencyInjection;
using PokeApiNet;
using PokemonApp.Infrastructure;
using PokemonApp.Infrastructure.PokemonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp.Api.UseCases.GetShakespeareanDescription
{
    public static class Dependencies
    {
        public static IServiceCollection AddGetPokemonDescriptionUseCase(this IServiceCollection services)
        {
            services.AddHttpClient<IShakespeareTranslationService, ShakespeareTranslationService>();
            services.AddSingleton<IPokemonService, PokemonService>();
            services.AddSingleton(_ => new PokeApiClient());

            return services;
        }

    }
}
