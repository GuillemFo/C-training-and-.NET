using weather_app.Models;

public interface IGeocodingService
{
	Task<City?> SearchCity(string city);
}
