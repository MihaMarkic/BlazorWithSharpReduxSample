using BlazorWithSharpRedux.Models;
using BlazorWithSharpRedux.Reducers;
using BlazorWithSharpRedux.Services;
using BlazorWithSharpRedux.State;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using Sharp.Redux;
using Sharp.Redux.Actions;
using System;
using System.Threading.Tasks;
using SimpleJson;
using System.Collections.Generic;
using BlazorReduxDevToolsExtension;

namespace BlazorWithSharpRedux
{
    public static class Program
    {
        static ReduxDispatcher<AppState, Reducer> dispatcher;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SharRedux in Blazor");
            var appState = new AppState(
                new CounterState(0), 
                new FetchDataState(new WeatherForecast[0], isLoading: false, error: null));
            dispatcher = new ReduxDispatcher<AppState, Reducer>(
                initialState: appState,
                reducer: new Reducer(),
                notificationScheduler: TaskScheduler.Current);
            bool areDevToolsAvailable = ReduxDevToolsExtension.IsAvailable();
            if (areDevToolsAvailable)
            {
                ReduxDevToolsExtension.Connect();
                ReduxDevToolsExtension.Init(appState);
                ReduxDevToolsExtension.Subscribe();
                ReduxDevToolsExtension.MessageReceived += ReduxDevToolsExtension_MessageReceived;
                dispatcher.StateChanged += (s, e) =>
                {
                    if (!(e.Action is InitAction))
                    {
                        ReduxDevToolsExtension.Send(e.Action, e.State);
                    }
                };
            }

            var serviceProvider = new BrowserServiceProvider(configure =>
            {
                configure.AddSingleton<IReduxDispatcher>(dispatcher);
                configure.AddSingleton<IReduxDispatcher<AppState>>(dispatcher);
                configure.AddSingleton<Communicator>();
            });
            dispatcher.Start(); 

            new BrowserRenderer(serviceProvider).AddComponent<Main>("app");
        }

        private static void ReduxDevToolsExtension_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine($"Received message: '{e.Message}'");
            var deserialized = SimpleJson.SimpleJson.DeserializeObject(e.Message);
            Console.WriteLine($"Deserialized is {deserialized.GetType().Name}");
        }

        public static void ApplyReduxAction(string stateJson)
        {
           
            //Console.WriteLine($"Deserialized: '{deserialized.Count}'");
            //var counter = (IDictionary<string, object>)deserialized[nameof(AppState.Counter)];
            //Console.WriteLine($"Counter is {counter[nameof(CounterState.Value)]}");
            //var ignore = dispatcher.ResetStateAsync(state);
        }
    }
}
