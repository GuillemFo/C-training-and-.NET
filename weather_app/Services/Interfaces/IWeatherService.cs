using weather_app.Models;

public interface IWeatherService
{
	Task<WeatherData?> GetWeather(string city);

}