using BlazorWithSharpRedux.Models;
using Sharp.Redux;

namespace BlazorWithSharpRedux.Actions
{
    public class WeatherForecastFetchSuccessAction: ReduxAction
    {
        public WeatherForecast[] Items { get; }

        public WeatherForecastFetchSuccessAction(WeatherForecast[] items) : base()
        {
            Items = items;
        }
    }
}
