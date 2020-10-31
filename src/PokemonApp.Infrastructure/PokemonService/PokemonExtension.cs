using Baseline;
using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonApp.Infrastructure.PokemonService
{
    public static class PokemonExtension
    { 
        public static string Description(this Pokemon pokemon)
        {
            var description =  $"{pokemon.Name} has {pokemon.Abilities.Count()} abilities, {pokemon.Abilities.Select(x => x.Ability.Name).Join(", ")}.";

            description = string.Concat(description, $"it has a total of {pokemon.Moves.Count()} moves, example: {pokemon.Moves.Select(x => x.Move.Name).Take(3).Join(", ")}.");

            description = string.Concat(description, $"it  weighs {pokemon.Weight} hectograms. it has {pokemon.Types.Count()} types, {pokemon.Types.Select(x => x.Type.Name).Join(", ")}.");

            return description;
        }
    }
}
