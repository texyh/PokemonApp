using PokeApiNet;
using PokemonApp.Domain.Exceptions;
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

        public PokemonService(PokeApiClient pokeApiClient)
        {
            _pokeApiClient = pokeApiClient;
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

                throw new PokemonNotFoundException(e.Message, $"Pokemon with name {name} was not found.");
            }

            return pokemon.Description();
        }
    }
}
