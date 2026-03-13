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
		public WeatherData GetWeather(string city)
		{
			return _weatherService.GetWeather(city);
		}
	}
}