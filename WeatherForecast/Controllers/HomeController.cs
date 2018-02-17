using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Return weather forecast by city name
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <returns>View with model</returns>
        [HttpGet]
        public async Task<ActionResult> WeatherForecastByCityName(string cityName)
        {
            // Create model
            var weatherAndForecast = new WeatherAndForecast();

            // Fill model with data and check status
            if (!await weatherAndForecast.GetData(cityName))
                return HttpNotFound();

            return View("Index", weatherAndForecast);
        }
    }
}