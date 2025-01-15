using Microsoft.AspNetCore.Mvc;
using projektMikolajBrzezinski.Models;
using projektMikolajBrzezinski.Services.IServices;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class NBPController : ControllerBase
{
    private readonly INBPService _NBPService;
    private readonly ICsvExport _csvExport;

    public NBPController(INBPService NBPService, ICsvExport csvExport)
    {
        _NBPService = NBPService;
        _csvExport = csvExport;
    }

    [HttpGet("csv/{currencyCode}")]
    public async Task<IActionResult> GetCsv(string currencyCode)
    {
        try
        {
            var exchangeRate = await _NBPService.GetExchangeRateAsync(currencyCode);

            var csvData = _csvExport.GenerateCsvFile(exchangeRate, currencyCode);

            return File(csvData, "text/csv", $"{currencyCode}_exchange_rate.csv");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("csv/multiple")]
    public async Task<IActionResult> GetCsvMultiple([FromQuery] List<string> currencyCodes)
    {
        try
        {
            var exchangeRates = new List<ExchangeRateResponse>();

            foreach (var currencyCode in currencyCodes)
            {
                var exchangeRate = await _NBPService.GetExchangeRateAsync(currencyCode);
                exchangeRates.Add(exchangeRate);
            }

            var csvData = _csvExport.GenerateCsvFile(exchangeRates);

            return File(csvData, "text/csv", "exchange_rates.csv");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("currency/{currencyCode}")]
    public async Task<IActionResult> GetEuroExchangeRate(string currencyCode)
    {
        return await GetExchangeRate(currencyCode);
    }


    [HttpGet("euro")]
    public async Task<IActionResult> GetEuroExchangeRate()
    {
        return await GetExchangeRate("EUR");
    }

    [HttpGet("usd")]
    public async Task<IActionResult> GetUsdExchangeRate()
    {
        return await GetExchangeRate("USD");
    }

    [HttpGet("gbp")]
    public async Task<IActionResult> GetGbpExchangeRate()
    {
        return await GetExchangeRate("GBP");
    }

    [HttpGet("chf")]
    public async Task<IActionResult> GetChfExchangeRate()
    {
        return await GetExchangeRate("CHF");
    }

    [HttpGet("cad")]
    public async Task<IActionResult> GetCadExchangeRate()
    {
        return await GetExchangeRate("CAD");
    }

    private async Task<IActionResult> GetExchangeRate(string currencyCode)
    {
        try
        {
            var result = await _NBPService.GetExchangeRateAsync(currencyCode);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
