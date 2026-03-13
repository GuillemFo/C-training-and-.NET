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

/*
Advantages and disadvantages of default constructor. Need to evaluate what i prefer and what is actually the standard way.
Advantages:

Guarantees fields have default values

CityName = "N/A", numeric fields = 0

Prevents null reference errors without extra annotations or checks

C++/C-style familiarity

You’re used to constructors initializing structs or classes

Makes it easy to reason about object state

Works well with older versions of C#

No required keyword

No nullable reference types to worry about

Safe fallback values

Even if a developer forgets to set CityName, you won’t crash

Disadvantages:

Can hide bugs

If you forget to set real data, you might return "N/A" instead of noticing a problem

With required or nullable checks, the compiler would alert you

Extra boilerplate

You have to maintain default values in constructor and when overriding with real data

Slightly more verbose than object initializers or required

Less explicit intent

Someone reading the code might not immediately know which fields are mandatory

Default constructor masks “this property must be set” vs “optional”

*/