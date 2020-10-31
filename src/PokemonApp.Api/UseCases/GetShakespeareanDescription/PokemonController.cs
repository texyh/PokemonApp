using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Application.UseCases.GetShakespeareanDescription;

namespace PokemonApp.Api.UseCases.GetShakespeareanDescription
{
    [Route("pokemon")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PokemonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetGetDescriptionAsync(string name)
        {
            return Result.For(await _mediator.Send(new GetDescriptionQuery { Name = name }));
        }
    }
}
