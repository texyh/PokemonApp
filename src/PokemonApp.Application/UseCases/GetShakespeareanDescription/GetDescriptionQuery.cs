using PokemonApp.Application.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Application.UseCases.GetShakespeareanDescription
{
    public class GetDescriptionQuery : IQuery<GetDescriptionResult>
    {
        public string Name { get; set; }
    }
}
