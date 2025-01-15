using projektMikolajBrzezinski.IServices;
using projektMikolajBrzezinski.Models;
using projektMikolajBrzezinski.Services.IServices;

namespace projektMikolajBrzezinski.Services
{
    public class NBPService : INBPService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonDeserializer _jsonDeserializer;
        private const string BaseApiUrl = "https://api.nbp.pl/api/exchangerates/rates/A/";

        public NBPService(HttpClient httpClient, IJsonDeserializer jsonDeserializer)
        {
            _httpClient = httpClient;
            _jsonDeserializer = jsonDeserializer;
        }

        public async Task<ExchangeRateResponse> GetExchangeRateAsync(string currencyCode)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                throw new ArgumentException("Currency code cannot be null or empty.", nameof(currencyCode));

            var url = $"{BaseApiUrl}{currencyCode}/?format=json";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching data from NBP API: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return _jsonDeserializer.Deserialize<ExchangeRateResponse>(json);
        }
    }
}
