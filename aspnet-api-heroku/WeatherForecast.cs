using System;

namespace aspnet_api_heroku
{
    /// <summary>
    /// A weather forecast for a given date.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>The date.</summary>
        public DateTime Date { get; set; }

        /// <summary>The temperature (°C).</summary>
        public int TemperatureC { get; set; }

        /// <summary>The temperature (°F).</summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>The summary of a WeatherForecast.</summary>
        public string Summary { get; set; }
    }
}
