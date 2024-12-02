using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace sample_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AzureWeatherSettings _azureWeatherSettings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<AzureWeatherSettings> azureWeatherSettings)
        {
            _logger = logger;
            _azureWeatherSettings = azureWeatherSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string url = $"{_azureWeatherSettings.BaseUrl}?api-version=1.0&query=29.76328%2C-95.36327&duration=5&subscription-key={_azureWeatherSettings.SubscriptionKey}";

            var client = new RestClient(url);
            var request = new RestRequest
            {
                Method = Method.Get
            };

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-ms-client-id", _azureWeatherSettings.ClientId);

            try
            {
                var response = await client.ExecuteAsync(request);

                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    _logger.LogError("Failed to fetch weather data: {StatusCode}", response.StatusCode);
                    return StatusCode(500, "Failed to retrieve weather data.");
                }

                var weatherObjects = JsonConvert.DeserializeObject<Root>(response.Content);
                var rng = new Random();

                var forecasts = weatherObjects?.forecasts?.Select(f => new WeatherForecast
                {
                    Date = f.date,
                    TemperatureC = (int)f.temperature.maximum.value,
                    Summary = Summaries[rng.Next(Summaries.Length)],
                    AirQuality = f.airAndPollen?.FirstOrDefault(a => a.name.Contains("AirQuality"))?.category
                }).ToList();

                return Ok(forecasts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching weather data.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
