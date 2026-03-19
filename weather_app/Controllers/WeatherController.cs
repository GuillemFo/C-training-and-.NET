/*
HTTP routes
Parse URL parameters
Return responses
Example: GET /weather/place
*/

using Microsoft.AspNetCore.Mvc;
using weather_app.Models;
using weather_app.Services;


namespace weather_app.Controllers
{
	[ApiController]
	[Route("weather")]
	public class WeatherController : ControllerBase
	{
		private readonly WeatherService _weatherService;

		public WeatherController(WeatherService weatherService)
		{
			_weatherService = weatherService;
		}

		[HttpGet("{city}")]
		public async Task<IActionResult>Weather(string city)
		{
			var weather = await _weatherService.GetWeather(city);
			
			if (weather == null)
			{
				return NotFound(new { message = $"Weather data for '{city}' not found" });
			}
			return Ok(weather);
		}
	}
}