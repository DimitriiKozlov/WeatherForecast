using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    /// <summary>
    /// This class get and store data from OpenWeatherMap
    /// </summary>
    public class WeatherAndForecast
    {
        /// <summary>
        /// Api key for OpenWeatherMap
        /// </summary>
        private const string ApiKey = "e28d685fe4ed068c63abd4d24b35d7ba";

        public WeatherModel Weather { get; set; }
        public ForecastModel Forecast { get; set; }

        /// <summary>
        /// Send request to OpenWeatherMap and store it.
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <returns>Status</returns>
        public async Task<bool> GetData(string cityName)
        {
            using (var client = new HttpClient())
            {
                // Create uri for request
                var uriWeather = new Uri($"http://api.openweathermap.org/data/2.5/find?q={cityName}&units=metric&appid={ApiKey}");
                var uriForecast = new Uri($"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric&appid={ApiKey}");

                // Send request
                var responseWeather = await client.GetAsync(uriWeather);
                var responseForecast = await client.GetAsync(uriForecast);

                // Check for success status code
                if (!responseWeather.IsSuccessStatusCode || !responseForecast.IsSuccessStatusCode)
                    return false;

                // Save data for weather
                var responseWeatherResult = await responseWeather.Content.ReadAsStringAsync();
                Weather = WeatherModel.FromJson(responseWeatherResult);

                // Save data for forecast
                var responseForecastResult = await responseForecast.Content.ReadAsStringAsync();
                Forecast = ForecastModel.FromJson(responseForecastResult);

                return true;
            }
        }
    }
}