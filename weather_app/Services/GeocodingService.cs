using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using weather_app.Models;

namespace weather_app.Services
{
	public class GeocodingService
	{
		private readonly HttpClient _httpClient;

		public GeocodingService()
		{
			_httpClient = new HttpClient();
		}

		public async Task<City?> GetCity(string city)
		{
			string url = $"";

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
		
	}
}