using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pokemon.Common.Options;
using Pokemon.Model;
using Pokemon.Model.PokemonSpecies;

namespace Pokemon.ServiceProvider.PokemonProvider
{
    public interface IPokemonApiService
    {
        Task<PokemonSpecie> GetPokemonSepecieAsync(string pokemon);
    }
    internal sealed class PokemonApiService: IPokemonApiService,IDisposable
    {
        private bool _disposed;
        private HttpClient _httpClient;
        private readonly ILogger<PokemonApiService> _logger;
        private readonly PokeApiOptions _pokeApiOptions;
        public PokemonApiService(IOptionsMonitor<PokeApiOptions> pokeApiOptions, ILogger<PokemonApiService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
            _pokeApiOptions= pokeApiOptions.CurrentValue;

        }
        public async Task<PokemonSpecie> GetPokemonSepecieAsync(string pokemon)
        {
            return await PokemonSepecieAsync(pokemon);
        }
        private async Task<PokemonSpecie> PokemonSepecieAsync(string pokemon)
        {
            try {

                var requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(_pokeApiOptions.DefaultSiteURL + _pokeApiOptions.DefaultBaseURL + $"{pokemon}"),
                    Method = HttpMethod.Get,
                };
                var httpResponse = await _httpClient.SendAsync(requestMessage);
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    return default;
                }
                var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                var deserializeObjectResponse = JsonSerializer.Deserialize<PokeApiBaseResponseObject>(jsonResponse);
                var description= await GetFlavorTextEntrieAsync(deserializeObjectResponse?.Species.Url);
                var pokemonSpecie = new PokemonSpecie()
                {
                    Name = deserializeObjectResponse?.Name,
                    Description = description
                };
                return pokemonSpecie;

            }
            catch(Exception ex)
            {
                _logger.LogError($"Internal server error : {ex.InnerException}");
                return default;
            }
        }
        
        private async Task<string> GetFlavorTextEntrieAsync(string url)
        {
            try
            {

                var requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                };
                var httpResponse = await _httpClient.SendAsync(requestMessage);
                var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                var deserializeObjectResponse = JsonSerializer.Deserialize<PokemonSpeciesBaseResponseObject>(jsonResponse);
                return deserializeObjectResponse?.FlavorTextEntries.FirstOrDefault(c => c.Language.Name == "en")?.FlavorText;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error : {ex.InnerException}");
                return default;
            }
        }

        [ExcludeFromCodeCoverage]
        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed && _httpClient != null)
            {
                var localHttpClient = _httpClient;
                localHttpClient.Dispose();
                _httpClient = null;
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
