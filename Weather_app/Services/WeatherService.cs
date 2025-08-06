
using Microsoft.VisualBasic;
using Model;
using Service_Contract;

namespace Services
{
    public class WeatherService : IWeatherService
    {

        private List<CityWeather> _cityWeather;

        public WeatherService() 
        {
            CityWeather c1=new CityWeather();
            CityWeather c2=new CityWeather();
            CityWeather c3=new CityWeather();
            c1.CityUniqueCode = "LDN";
            c1.CityName = "London";
            c1.DateAndTime = "2030-01-01 8:00";
            c1.TemperatureFahrenheit = 33;
            c2.CityUniqueCode = "NYC";
            c2.CityName = "London";
            c2.DateAndTime = "2030-01-01 3:00";  
            c2.TemperatureFahrenheit = 60;
            c3.CityUniqueCode = "PAR";
            c3.CityName = "Paris"; c3.DateAndTime = "2030-01-01 9:00";
            c3.TemperatureFahrenheit = 82;
            _cityWeather = new List<CityWeather>();
            _cityWeather.Add(c1);
            _cityWeather.Add(c2);
            _cityWeather.Add(c3);
        }

        public List<CityWeather> getWeather()
        {
            return _cityWeather;
        }

        public CityWeather getWeatherByCity(string cityCode)
        {
           foreach (CityWeather cityWeather in _cityWeather)
           {
                if(cityWeather.CityUniqueCode == cityCode)
                {
                    return cityWeather;
                }
           }
            return null;
        }
    }
}
