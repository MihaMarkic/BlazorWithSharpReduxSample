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
        readonly HttpClient http;
        public Communicator(IReduxDispatcher dispatcher, HttpClient http)
        {
            this.dispatcher = dispatcher;
            this.http = http;
        }
        public async Task FetchWeatherForecastAsync()
        {
            dispatcher.Dispatch(new WeatherForecastFetchStartAction());
            try
            {
                var forecasts = await http.GetJsonAsync<WeatherForecast[]>("/sample-data/weather.json");
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
