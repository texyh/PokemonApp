using PokemonApp.Domain.Helpers;
using PokemonApp.Infrastructure.ShakespeareTranslation;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Infrastructure
{
    public class ShakespeareTranslationService : IShakespeareTranslationService
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger _logger;

        private const string _baseUrl = "https://api.funtranslations.com/translate/shakespeare.json";

        public ShakespeareTranslationService(
            HttpClient httpClient,
            ILogger logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _logger = logger;
        }

        public async Task<string> Translate(string description)
        {
            using var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{_baseUrl}?text={description}"),
                Method = HttpMethod.Get,
            };

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                _logger.Error($"translation failed. error: {response.ReasonPhrase}");
                throw new InvalidOperationException(response.ReasonPhrase);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return (responseContent.FromJson<TranslationResponse>()).Contents.Translated;
        }
    }
}
