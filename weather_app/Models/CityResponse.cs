namespace weather_app.Models
{
	public class CityResponse
	{
		public List<City> results {get;set;} = new List<City>(); //To at least be an empty list instead of null.
	}

	public class City
	{
		public int id {get;set;}

		public string name {get;set;} = "";

		public float latitude {get;set;}

		public float longitude {get;set;}

		// public string country_code {get;set;}

		public string country {get;set;} = "";
	}
}