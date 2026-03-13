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
			//api call with trimmed extra spaces front and back string for name so no issues with api. (need to read api use)
			// normalize city name to set it as init val for data struct. (ciudad real to Ciudad Real or madrid to Madrid etc)
			// need to check how to store api data and how to access it to build our weather data object to return.

			return new WeatherData
			{
				CityName = city,
				TemperatureC = 20,
				Humidity = 50,
				WindSpeedKph = 10
			};
		}
		

	}
	
}