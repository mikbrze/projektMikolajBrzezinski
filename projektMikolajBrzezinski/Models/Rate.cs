using System.Text.Json.Serialization;

namespace projektMikolajBrzezinski.Models
{
    public class Rate
    {
        [JsonPropertyName("no")]
        public string? No { get; set; }

        [JsonPropertyName("effectiveDate")]
        public string? EffectiveDate { get; set; }

        [JsonPropertyName("mid")]
        public decimal Mid { get; set; }
    }
}
