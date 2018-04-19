using Sharp.Redux;
using Righthand.Immutable;

namespace BlazorWithSharpRedux.Actions
{
    public class WeatherForecastFetchFailureAction: BlazorReduxAction
    {
        public string Error { get; }

        public WeatherForecastFetchFailureAction(string error) : base()
        {
            Error = error;
        }

        public WeatherForecastFetchFailureAction Clone(Param<string>? error = null)
        {
            return new WeatherForecastFetchFailureAction(error.HasValue ? error.Value.Value : Error);
        }
    }
}
