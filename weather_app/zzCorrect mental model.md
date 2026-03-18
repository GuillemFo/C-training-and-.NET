First basic implementation:

1. Controller gets city

2. Controller calls WeatherService

3. WeatherService:
   - calls geocoding API
   - extracts lat/lon
   - calls weather API
   - extracts weather data
   - builds WeatherData

4. WeatherService returns WeatherData

5. Controller returns it to user (as JSON)


General idea of each part
Controller:
- receives "berlin"
- calls service

Service:
- calls APIs
- parses JSON
- formats data
- builds WeatherData

Model:
- stores final clean data

Controller:
- returns result to user