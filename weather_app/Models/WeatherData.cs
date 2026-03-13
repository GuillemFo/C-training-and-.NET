/*
My service structure object
WeatherData
TemperatureC
Humidity
WindSpeed
City
etc...
*/

namespace weather_app.Models
{
	public class WeatherData
	{
		public string CityName {get; set;} = "N/A";
		public int TemperatureC {get; set;} = 0;
		public int Humidity {get; set;} = 0;
		public int WindSpeedKph {get; set;} = 0;

		public WeatherData()
		{
			// default constructor that will always set the data to its default params we set above as a fallback if error.
		}
	}
}