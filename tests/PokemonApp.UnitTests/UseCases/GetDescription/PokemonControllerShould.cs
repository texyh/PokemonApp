using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PokemonApp.Api.UseCases.GetShakespeareanDescription;
using PokemonApp.Application.UseCases.GetShakespeareanDescription;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PokemonApp.UnitTests.UseCases.GetDescription
{
    public class PokemonControllerShould
    {

        [Fact]
        public  async Task Get_Pokemon_Description()
        {
            var result = new SuccessResult("Charizard", "charizard flies 'round the sky in search of powerful opponents.'");
            var mockHandler = new Mock<IMediator>();
            mockHandler.Setup(x => x.Send(It.IsAny<GetDescriptionQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(result);

            var sut = new PokemonController(mockHandler.Object);

            var response = await  sut.GetGetDescriptionAsync("Charizard");

            var httpResponse = response as OkObjectResult;
            httpResponse.Value.Should().Be(result);
        }
    }
}
