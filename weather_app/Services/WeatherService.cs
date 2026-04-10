/*
Business logic
Caching
Unit conversion
Provider fallback
Something like GetWeather(city)
*/
// using System;
// using System.Net.Http;
// using System.Threading.Tasks;
// using System.Text.Json;
// using weather_app.Models;
// using weather_app.Services;

// namespace weather_app.Services
// {
// 	public class WeatherService
// 	{
// 		private readonly HttpClient _httpClient;
// 		private readonly CityResponse _cityResponse;

// 		public WeatherService()
// 		{
// 			_httpClient = new HttpClient();
// 		}

// 		public WeatherService(CityResponse cityResponse)
// 		{
// 			_cityResponse = cityResponse;
// 		}

// 		public async Task<WeatherData?> GetWeather(string city)
// 		{

			
// 			string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m,relative_humidity_2m&forecast_days=1";
			
// 			var response = await _httpClient.GetAsync(url);
// 			response.EnsureSuccessStatusCode();

// 			var json = await response.Content.ReadAsStringAsync();

// 			var apiData = JsonSerializer.Deserialize<WeatherApiResponse>(json);

// 			if (apiData == null || apiData.current == null)
// 			{
// 				// Handle no apiData 
// 				return null; // temp protection
// 			}

// 			Console.WriteLine(apiData.current.temperature_2m);
// 			Console.WriteLine(apiData.current.wind_speed_10m);
			
			
// 			return new WeatherData
// 			{
// 				CityName = city,
// 				Temperature = apiData.current.temperature_2m,
// 				// Temperature_type = apiData.current_Units.temperature_2m,
// 				WindSpeed = apiData.current.wind_speed_10m,
// 				// WindSpeed_type = apiData.current_Units.wind_speed_10m,
// 				Humidity = apiData.current.relative_humidity_2m,
// 				// Humidity_type = apiData.current_Units.relative_humidity_2m,
// 			};
// 		}
		

// 	}
	
// }
// REORGANIZING METHODS FOR ONE JOB EACH

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using weather_app.Models;

namespace weather_app.Services
{

	public class WeatherService : IWeatherService
	{
		private readonly HttpClient _httpClient;
		private readonly IGeocodingService _geocodingService;
		
		public WeatherService(IGeocodingService geocodingService)
		{
			_httpClient = new HttpClient();
			_geocodingService = geocodingService;
		}

		public async Task<WeatherData?> GetWeather(string city)
		{
			var cityInfo = await _geocodingService.SearchCity(city);

			if (cityInfo == null)
				return null;

			return await GetWeatherByCoordinates(city, cityInfo.latitude, cityInfo.longitude);
		}

		private async Task<WeatherData?> GetWeatherByCoordinates(string city, float latitude, float longitude)
		{
			var apiData = await FetchWeatherData(latitude, longitude);

			if (apiData == null || apiData.current == null)
				return null;

			return MapToWeatherData(city, apiData);
		}

		private async Task<WeatherApiResponse?> FetchWeatherData(float latitude, float longitude)
		{
			string url = BuildWeatherUrl(latitude, longitude);

			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<WeatherApiResponse>(json);
		}

		private string BuildWeatherUrl(float latitude, float longitude)
		{
			return ($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m,relative_humidity_2m&forecast_days=1");
		}

		private WeatherData MapToWeatherData(string city, WeatherApiResponse apiData)
		{
			return new WeatherData
			{
				CityName = city,
				Temperature = apiData.current!.temperature_2m,
				WindSpeed = apiData.current.wind_speed_10m,
				Humidity = apiData.current.relative_humidity_2m
			};
		}
		
	}
	
}