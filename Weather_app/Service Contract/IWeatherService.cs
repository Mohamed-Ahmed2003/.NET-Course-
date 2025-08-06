using Model;

namespace Service_Contract
{
    public interface IWeatherService
    {
        public List<CityWeather> getWeather();
        public CityWeather getWeatherByCity(string cityCode);
    }
}