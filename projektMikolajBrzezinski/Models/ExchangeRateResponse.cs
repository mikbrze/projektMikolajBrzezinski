using System.Text.Json.Serialization;

namespace projektMikolajBrzezinski.Models
{
    public class ExchangeRateResponse
    {
        [JsonPropertyName("table")]
        public string? Table { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("rates")]
        public required List<Rate> Rates { get; set; }
    }
}
