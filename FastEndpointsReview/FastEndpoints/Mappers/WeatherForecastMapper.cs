using FastEndpoints;
using FastEndpointsApi.Contracts.Requests;
using FastEndpointsApi.Contracts.Responses;
using FastEndpointsApi.Models;

namespace FastEndpointsApi.Mappers
{
    public class WeatherForecastMapper : Mapper<WeatherForecastRequest,WeatherForecastResponse,WeatherForecast>
    {
        public override WeatherForecastResponse FromEntity(WeatherForecast e)
        {
            return new WeatherForecastResponse
            {

                Date = e.Date,
                TemperatureC = e.TemperatureC,
                TemperatureF = e.TemperatureF,
                Summary = e.Summary,
            };
        }
    }
}
