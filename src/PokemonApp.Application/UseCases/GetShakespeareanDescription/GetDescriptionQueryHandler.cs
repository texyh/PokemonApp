using PokemonApp.Application.Abstractions.Queries;
using PokemonApp.Infrastructure;
using PokemonApp.Infrastructure.PokemonService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonApp.Application.UseCases.GetShakespeareanDescription
{
    public class GetDescriptionQueryHandler : IQueryHandler<GetDescriptionQuery, GetDescriptionResult>
    {
        private readonly IShakespeareTranslationService _shakespeareTranslationService;

        private readonly IPokemonService _pokemonService;

        public GetDescriptionQueryHandler(IShakespeareTranslationService shakespeareTranslationService, IPokemonService pokemonService)
        {
            _shakespeareTranslationService = shakespeareTranslationService;
            _pokemonService = pokemonService;
        }

        public async Task<GetDescriptionResult> Handle(GetDescriptionQuery request, CancellationToken cancellationToken)
        {
            var description = await _pokemonService.GetDescription(request.Name);
            var translation = await _shakespeareTranslationService.Translate(description);

            return  new SuccessResult(request.Name, translation);
        }
    }
}
