using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp.Application.UseCases.GetShakespeareanDescription
{
    public class GetDescriptionQueryValidator : AbstractValidator<GetDescriptionQuery>
    {
        public GetDescriptionQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }

    }
}
