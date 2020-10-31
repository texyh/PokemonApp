using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Application.UseCases.GetShakespeareanDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp.Api.UseCases.GetShakespeareanDescription
{
    public static class Result
    {
        public static IActionResult For(GetDescriptionResult result)
        {
            return result switch
            {
                SuccessResult r => new OkObjectResult(r),
                ErrorResult e => new NotFoundObjectResult(e.Message),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
        }
    }
}
