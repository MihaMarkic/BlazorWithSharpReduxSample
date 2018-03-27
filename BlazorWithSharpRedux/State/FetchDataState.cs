using BlazorWithSharpRedux.Models;
using Righthand.Immutable;

namespace BlazorWithSharpRedux.State
{
    public readonly struct FetchDataState
    {
        public WeatherForecast[] Forecasts { get; }
        public bool IsLoading { get; }
        public string Error { get; }

        public FetchDataState(WeatherForecast[] forecasts, bool isLoading, string error)
        {
            Forecasts = forecasts;
            IsLoading = isLoading;
            Error = error;
        }

        public FetchDataState Clone(Param<WeatherForecast[]>? forecasts = null, Param<bool>? isLoading = null, Param<string>? error = null)
        {
            return new FetchDataState(forecasts.HasValue ? forecasts.Value.Value : Forecasts,
isLoading.HasValue ? isLoading.Value.Value : IsLoading,
error.HasValue ? error.Value.Value : Error);
        }
    }
}
