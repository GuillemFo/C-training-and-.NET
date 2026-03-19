/*
Business logic
Caching
Unit conversion
Provider fallback
Something like GetWeather(city)
*/
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using weather_app.Models;

namespace weather_app.Services
{
	public class WeatherService
	{
		private readonly HttpClient _httpClient;

		public WeatherService()
		{
			_httpClient = new HttpClient();
		}

		public async Task<WeatherData?> GetWeather(string city)
		{
			string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m,relative_humidity_2m&forecast_days=1";
			
			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();

			var apiData = JsonSerializer.Deserialize<WeatherApiResponse>(json);

			if (apiData == null || apiData.current == null)
			{
				return null;
			}

			Console.WriteLine(apiData.current.temperature_2m);
			Console.WriteLine(apiData.current.wind_speed_10m);
			
			
			return new WeatherData
			{
				CityName = city,
				Temperature = apiData.current.temperature_2m,
				// Temperature_type = apiData.current_Units.temperature_2m,
				WindSpeed = apiData.current.wind_speed_10m,
				// WindSpeed_type = apiData.current_Units.wind_speed_10m,
				Humidity = apiData.current.relative_humidity_2m,
				// Humidity_type = apiData.current_Units.relative_humidity_2m,
			};
		}
		

	}
	
}