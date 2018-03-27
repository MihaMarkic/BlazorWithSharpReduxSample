using BlazorWithSharpRedux.Actions;
using BlazorWithSharpRedux.Models;
using Microsoft.AspNetCore.Blazor;
using Sharp.Redux;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithSharpRedux.Services
{
    public class Communicator
    {
        readonly IReduxDispatcher dispatcher;
        public HttpClient Http { get; set; }
        public Communicator(IReduxDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
        public async Task FetchWeatherForecastAsync()
        {
            dispatcher.Dispatch(new WeatherForecastFetchStartAction());
            try
            {
                var forecasts = await Http.GetJsonAsync<WeatherForecast[]>("/sample-data/weather.json");
                // simulate slow network
                await Task.Delay(5000);
                dispatcher.Dispatch(new WeatherForecastFetchSuccessAction(forecasts));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new WeatherForecastFetchFailureAction(ex.Message));
            }
        }
    }
}
