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
		
		public WeatherService(HttpClient httpClient, IGeocodingService geocodingService)
		{
			_httpClient = httpClient;
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