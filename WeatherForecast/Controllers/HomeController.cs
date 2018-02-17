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

        [HttpGet]
        public async Task<ActionResult> WeatherForecastByCityName(string cityName)
        {
            var weatherAndForecast = new WeatherAndForecast();
            if (!await weatherAndForecast.GetData(cityName))
                return HttpNotFound();
            return View("Index", weatherAndForecast);
        }
    }
}