using projektMikolajBrzezinski.IServices;
using System.Text.Json;

namespace projektMikolajBrzezinski.Services
{
    public class JsonDeserializer : IJsonDeserializer
    {
        public T Deserialize<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentException("JSON string cannot be null or empty.", nameof(json));

            return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidOperationException("Failed to deserialize JSON.");
        }
    }
}
