using projektMikolajBrzezinski.Models;

namespace projektMikolajBrzezinski.Services.IServices
{
    public interface INBPService
    {
        Task<ExchangeRateResponse> GetExchangeRateAsync(string currencyCode);
    }
}