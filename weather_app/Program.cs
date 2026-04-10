using System.Reflection;
using System.IO;
using weather_app.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IGeocodingService, GeocodingService>();
builder.Services.AddHttpClient();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/openapi/v1.json", "v1");
		options.RoutePrefix = string.Empty;
	});
}

//app.UseHttpsRedirection();

app.MapControllers();
app.Run();

