/*
Business logic
Caching
Unit conversion
Provider fallback
Something like GetWeather(city)
*/
using weather_app.Models;

namespace weather_app.Services
{
	public class WeatherService
	{
		public WeatherData GetWeather(string city)
		{
			return new WeatherData
			{
				CityName = "city",
				TemperatureC = 20,
				Humidity = 50,
				WindSpeedKph = 10
			};
		}
		

	}
	
}