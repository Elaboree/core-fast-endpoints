using FastEndpoints;
using FastEndpointsApi.Contracts.Requests;
using FastEndpointsApi.Contracts.Responses;
using FastEndpointsApi.Mappers;
using FastEndpointsApi.Models;

namespace FastEndpointsApi.Endpoints
{

    //REPR -> (Request - Endpoint - Response) defines web API endpoints as having three components 
    public class WeatherForecastEndpoint : Endpoint<WeatherForecastRequest, WeatherForecastsResponse, WeatherForecastMapper>
    {
        private static readonly string[] Sumamries =
        {
            "Freezing","Bracing","Chilly","Cool","Mild","Balmy","Hot" ,"Scorching"
        };

        //Dependency Injection
        public ILogger<WeatherForecastEndpoint> Logger { get; init; }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("weather/{days}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(WeatherForecastRequest req, CancellationToken ct)
        {
            Logger.LogDebug("Retrieving weather for {Days} days", req.Days);

            var forecasts = Enumerable.Range(1, req.Days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Sumamries[Random.Shared.Next(Sumamries.Length)]
            }).ToArray();

            var response = new WeatherForecastsResponse
            {
                Forecasts = forecasts.Select(Map.FromEntity)
            };

            await SendAsync(response, cancellation: ct);
        }
    }

}
