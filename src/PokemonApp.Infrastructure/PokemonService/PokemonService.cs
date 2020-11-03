using PokeApiNet;
using PokemonApp.Domain.Exceptions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Infrastructure.PokemonService
{
    public interface IPokemonService
    {
        Task<string> GetDescription(string name);
    }

    public class PokemonService : IPokemonService
    {
        private readonly PokeApiClient _pokeApiClient;

        private readonly ILogger _logger;


        public PokemonService(PokeApiClient pokeApiClient, ILogger logger)
        {
            _pokeApiClient = pokeApiClient;
            _logger = logger;
        }

        public async Task<string> GetDescription(string name)
        {
            Pokemon pokemon;
            try
            {
                 pokemon = await _pokeApiClient.GetResourceAsync<Pokemon>(name);

            }
            catch (Exception e)
            {
                _logger.Error($"Pokemon with name {name} was not found.");
                throw new PokemonNotFoundException(e.Message, $"Pokemon with name {name} was not found.");
            }

            return pokemon.Description();
        }
    }
}
