using System.Text;
using projektMikolajBrzezinski.Models;
using projektMikolajBrzezinski.IServices;
using projektMikolajBrzezinski.Services.IServices;

namespace projektMikolajBrzezinski.Services
{
    public class CsvExport : ICsvExport
    {
        public byte[] GenerateCsvFile(List<ExchangeRateResponse> exchangeRates)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Currency,Date,Rate");

            foreach (var exchangeRate in exchangeRates)
            {
                foreach (var rate in exchangeRate.Rates)
                {
                    stringBuilder.AppendLine($"{exchangeRate.Currency},{rate.EffectiveDate},{rate.Mid}");
                }
            }

            return Encoding.UTF8.GetBytes(stringBuilder.ToString());
        }

        public byte[] GenerateCsvFile(ExchangeRateResponse exchangeRate, string currencyCode)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Currency,Date,Rate");

            foreach (var rate in exchangeRate.Rates)
            {
                stringBuilder.AppendLine($"{exchangeRate.Currency},{rate.EffectiveDate},{rate.Mid}");
            }

            return Encoding.UTF8.GetBytes(stringBuilder.ToString());
        }
    }
}
