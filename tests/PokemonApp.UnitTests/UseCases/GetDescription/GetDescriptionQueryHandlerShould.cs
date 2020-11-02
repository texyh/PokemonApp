using FluentAssertions;
using Moq;
using PokemonApp.Application.UseCases.GetShakespeareanDescription;
using PokemonApp.Infrastructure;
using PokemonApp.Infrastructure.PokemonService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokemonApp.UnitTests.UseCases.GetDescription
{
    public class GetDescriptionQueryHandlerShould
    {

        [Fact]
        public async Task Get_Shakespeare_Pokemon_Description()
        {
            var mockTranslator = new Mock<IShakespeareTranslationService>();
            mockTranslator.Setup(x => x.Translate(It.IsAny<string>()))
                .ReturnsAsync("the charizard flies 'round the sky in search of powerful opponents.'");
            var mockPokemonClient = new Mock<IPokemonService>();
            mockPokemonClient.Setup(x => x.GetDescription(It.IsAny<string>()))
                .ReturnsAsync("the charizard flies 'round the sky in search of powerful opponents.'");
            var sut = new GetDescriptionQueryHandler(mockTranslator.Object, mockPokemonClient.Object);

            var result = await sut.Handle(new GetDescriptionQuery { Name = "Charizard" }, new System.Threading.CancellationToken()) as SuccessResult;

            result.Name.Should().Be("Charizard");
            result.Description.Should().Be("the charizard flies 'round the sky in search of powerful opponents.'");

        }
    }
}
