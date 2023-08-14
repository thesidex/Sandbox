using Microsoft.AspNetCore.Mvc;

namespace sample_app.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Shared.WeatherForecast>> GetAsync()
        {
            try
            {


                sampleApi.Client client = new sampleApi.Client("http://localhost:5000", new HttpClient());

                ICollection<sampleApi.WeatherForecast> forecasts = null;

                forecasts = await client.WeatherForecastAsync();


                List<Shared.WeatherForecast> retCollection = new List<Shared.WeatherForecast>();

                foreach (sampleApi.WeatherForecast forecast in forecasts)
                {
                    Shared.WeatherForecast retData = new Shared.WeatherForecast();

                    retData.Date = forecast.Date.DateTime;
                    retData.TemperatureC = forecast.TemperatureC;
                    //retData.Summary = forecast.Summary;
                    retData.Category = forecast.Category;
                    retCollection.Add(retData);
                }


                return retCollection;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
