using dto;
using System.Text.Json;

namespace frontend.Services;

public class WeatherForecastService
{
    private HttpClient client;
    private JsonSerializerOptions jsonOpts;

    public WeatherForecastService(HttpClient client)
    {
        this.client = client;
        this.jsonOpts = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<WeatherForecast[]> GetForecastAsync()
    {
        var response = await client.GetAsync("weatherforecast");
        var jsonStr = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<WeatherForecast[]>(jsonStr, jsonOpts);
    }
}
