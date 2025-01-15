using projektMikolajBrzezinski.Models;

namespace projektMikolajBrzezinski.Services.IServices
{
    public interface ICsvExport
    {
        byte[] GenerateCsvFile(List<ExchangeRateResponse> exchangeRates);
        byte[] GenerateCsvFile(ExchangeRateResponse exchangeRate, string currencyCode);
    }
}