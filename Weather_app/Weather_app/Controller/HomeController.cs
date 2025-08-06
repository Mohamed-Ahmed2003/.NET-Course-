using Microsoft.AspNetCore.Mvc;
using Model;
using Service_Contract;

namespace Weather_app.Controller
{
    public class HomeController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [HttpGet]
        [Route("/")]
        public IActionResult allWeather()
        {
            List<CityWeather> data = new List<CityWeather>();
            data = _weatherService.getWeather();
            return new JsonResult(data);
        }
       
        [Route("/weather/{Code}")]
        public IActionResult getWeatherWithCity(string code) 
        {
            CityWeather weather = new CityWeather();
            weather = _weatherService.getWeatherByCity(code);
            if(weather == null) 
                return BadRequest("there is no city with this code ");
            else
                return Ok(weather);
        }
    }
}
