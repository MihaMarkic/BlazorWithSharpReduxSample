using BlazorWithSharpRedux.Models;
using Sharp.Redux;

namespace BlazorWithSharpRedux.Actions
{
    public class WeatherForecastFetchSuccessAction: BlazorReduxAction
    {
        public WeatherForecast[] Items { get; }

        public WeatherForecastFetchSuccessAction(WeatherForecast[] items) : base()
        {
            Items = items;
        }
    }
}
