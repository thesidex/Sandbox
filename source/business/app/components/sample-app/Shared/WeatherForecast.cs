using System;

namespace sample_app.Shared
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Category { get; set; }

        // The user does not require this property to be displayed in the UI. But let's comment it out for now in case we need it again.
        //public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
