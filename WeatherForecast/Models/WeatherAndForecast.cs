using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class WeatherAndForecast
    {
        private const string ApiKey = "e28d685fe4ed068c63abd4d24b35d7ba";
        public WeatherModel Weather { get; set; }
        public ForecastModel Forecast { get; set; }

        public async Task<bool> GetData(string cityName)
        {
            using (var client = new HttpClient())
            {
                var uriWeather = new Uri($"http://api.openweathermap.org/data/2.5/find?q={cityName}&units=metric&appid={ApiKey}");
                var uriForecast = new Uri($"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric&appid={ApiKey}");

                var responseWeather = await client.GetAsync(uriWeather);
                var responseForecast = await client.GetAsync(uriForecast);

                if (!responseWeather.IsSuccessStatusCode || !responseForecast.IsSuccessStatusCode)
                    return false;

                var responseWeatherResult = await responseWeather.Content.ReadAsStringAsync();
                Weather = WeatherModel.FromJson(responseWeatherResult);

                var responseForecastResult = await responseForecast.Content.ReadAsStringAsync();
                Forecast = ForecastModel.FromJson(responseForecastResult);

                return true;
            }
        }
    }
}