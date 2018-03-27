using System.Threading;
using System.Threading.Tasks;
using BlazorWithSharpRedux.Actions;
using BlazorWithSharpRedux.Models;
using BlazorWithSharpRedux.State;
using Sharp.Redux;

namespace BlazorWithSharpRedux.Reducers
{
    public class FetchDataReducer : IReduxReducer<FetchDataState>
    {
        public Task<FetchDataState> ReduceAsync(FetchDataState state, ReduxAction action, CancellationToken ct)
        {
            FetchDataState result;
            switch (action)
            {
                case WeatherForecastFetchStartAction start:
                    result = state.Clone(forecasts: new WeatherForecast[0], isLoading: true, error: null);
                    break;
                case WeatherForecastFetchFailureAction failure:
                    result = state.Clone(isLoading: false, error: failure.Error);
                    break;
                case WeatherForecastFetchSuccessAction success:
                    result = state.Clone(forecasts: success.Items, isLoading: false);
                    break;
                default:
                    result = state;
                    break;
            }
            return Task.FromResult(result);
        }
    }
}
