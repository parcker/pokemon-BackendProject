using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pokemon.Common.Options;
using Pokemon.Model;

namespace Pokemon.ServiceProvider.ShakespeareTranslator
{
    public interface IShakespeareTranslatorApiService
    {
        Task<string> TranslateToShakespeareanAsync(string description);
    }
    internal sealed class ShakespeareTranslatorApiService: IShakespeareTranslatorApiService,IDisposable
    {
        private readonly ShakespeareOption _shakespeareOption;
        private  HttpClient _httpClient;
        private readonly ILogger<ShakespeareTranslatorApiService> _logger;
        private bool _disposed;
        public ShakespeareTranslatorApiService(IOptionsMonitor<ShakespeareOption> shakespeareOption, ILogger<ShakespeareTranslatorApiService> logger, IHttpClientFactory httpClientFactory)
        {
            _shakespeareOption = shakespeareOption.CurrentValue;
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<string> TranslateToShakespeareanAsync(string text)
        {
            return await TranslateAsync(text);
        }
        private async Task<string>TranslateAsync(string text)
        {
            try {
               
                var requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(_shakespeareOption.DefaultSiteURL + _shakespeareOption.DefaultBaseURL + $"?text={text}"),
                    Method = HttpMethod.Get,
                    
                };
                var httpResponse = await _httpClient.SendAsync(requestMessage);
                
                var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                var deserializeObjectResponse = JsonSerializer.Deserialize<ShakespeareTranslateResponseObject>(jsonResponse);
                return deserializeObjectResponse is not null ? deserializeObjectResponse.Contents.Translated : string.Empty;
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
