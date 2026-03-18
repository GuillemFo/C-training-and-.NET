using System.Text.Json.Serialization;

namespace weather_app.Models
{
	public class WeatherApiResponse
	{
	// If it’s just cosmetic (renaming for clarity) → do it in the model with [JsonPropertyName]
	// If it’s functional (combining, transforming, or filtering data) → do it in the service
		public float latitude {get;set;}
		public float longitude {get;set;}

		// public CurrentUnits? Current_Units {get;set;}
		public CurrentWeather? current {get;set;}

	}

	// public class CurrentUnits
	// {
	// 	public required string temperature_2m {get;set;}

	// 	public required string wind_speed_10m {get;set;}
		
	// 	public required string relative_humidity_2m{get;set;}
	// }
	public class CurrentWeather
	{
		public required string time {get;set;}
		
		public float temperature_2m {get;set;}

		public float wind_speed_10m {get;set;}

		public int relative_humidity_2m {get;set;}
	}
}