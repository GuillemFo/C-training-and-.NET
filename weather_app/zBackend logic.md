Controller
	Parses the URL
	Routes
	Headers
	HTTP responses
		Example request: GET /weather/place
		Controller extracts place
		calls service
		return result
	Controller translates HTTP requests so services can execute the logic.

Service
	Always receives the same object
	Manages fallbacks
	Caches info to not saturate the api
	If i want to change temperature from celsius to kelvin i would do it here ( having in mind that the object will always be celsius based)
	Calls the provider specific function

Provider
	Will ask the api
	Parse the json and translate or convert if needed
	Return always the same object that service needs