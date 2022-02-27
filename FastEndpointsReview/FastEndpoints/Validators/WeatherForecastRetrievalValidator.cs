using FastEndpoints.Validation;
using FastEndpointsApi.Contracts.Requests;

namespace FastEndpointsApi.Validators
{
    public class WeatherForecastRetrievalValidator : Validator<WeatherForecastRequest>
    {
        public WeatherForecastRetrievalValidator()
        {
            RuleFor(x => x.Days)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Weather forecast days must be at least 1")
                .LessThanOrEqualTo(14)
                .WithMessage("Weather forecast can't be retrieved past 14 days");
        }
    }
}