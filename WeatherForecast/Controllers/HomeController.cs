using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> WeatherForecastByCityName(string cityName)
        {
            using (var client = new HttpClient())
            {
                var apiKey = "e28d685fe4ed068c63abd4d24b35d7ba";
                var uri = new Uri($"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={apiKey}");

                var response = await client.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                    return HttpNotFound();

                var responseResult = await response.Content.ReadAsStringAsync();

                var wfc = JsonConvert.DeserializeObject<WeatherForecastModel>(responseResult);

                return View("Index", wfc);
            }
        }
    }
}