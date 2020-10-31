using FluentAssertions;
using PokemonApp.Api.UseCases.GetShakespeareanDescription;
using PokemonApp.Application.UseCases.GetShakespeareanDescription;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xbehave;
using Xunit;

namespace PokemonApp.IntegrationTests.AcceptanceTests
{
    [Collection("Acceptance-Tests")]
    public class GetPokemonDescriptionScenario : IClassFixture<TestServerFixture>
    {
        private TestServerFixture _fixture;

        public GetPokemonDescriptionScenario(TestServerFixture testServerFixture)
        {
            testServerFixture.CreateTestEnvironment(services =>
            {
                services.AddGetPokemonDescriptionUseCase();
            });
            _fixture = testServerFixture;
        }

        [Scenario]
        public void Get_Poken_ShakespeareDescription(string name, string description)
        {
            "Given a pokemon name".x(() => name = "charizard");

            "When the description is retrieved".x(async () => description = (await GetPokemonDescription(name)).Description);

            "Then the description should be valid".x(() => description.Should().NotBeNullOrEmpty());
        }

        private async Task<SuccessResult> GetPokemonDescription(string name)
        {
            var cancellation = new CancellationTokenSource();
            cancellation.CancelAfter(TimeSpan.FromSeconds(30));
            return await _fixture.GetAsync<SuccessResult>($"pokemon/{name}", cancellation.Token);
        }
    }
}
