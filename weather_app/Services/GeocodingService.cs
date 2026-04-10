using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using weather_app.Models;

namespace weather_app.Services
{
	public class GeocodingService : IGeocodingService
	{
		private readonly HttpClient _httpClient;

		public GeocodingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<City?> SearchCity(string city)
		{
			string url = BuildLocationUrl(city);

			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();

			var cityInfo = JsonSerializer.Deserialize<CityResponse>(json);
			if (cityInfo == null || cityInfo.results.Count == 0)
			{
				return null;
			}

			return cityInfo.results[0];
		}

		private string BuildLocationUrl(string city_name)
		{	
			return ($"https://geocoding-api.open-meteo.com/v1/search?name={city_name}&count=1&language=en&format=json");
		}
		
	}
}