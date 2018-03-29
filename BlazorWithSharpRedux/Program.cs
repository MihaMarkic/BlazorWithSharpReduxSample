using BlazorWithSharpRedux.Models;
using BlazorWithSharpRedux.Reducers;
using BlazorWithSharpRedux.Services;
using BlazorWithSharpRedux.State;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using Sharp.Redux;
using System.Threading.Tasks;

namespace BlazorWithSharpRedux
{
    class Program
    {
        static void Main(string[] args)
        {
            var appState = new AppState(
                new CounterState(0), 
                new FetchDataState(new WeatherForecast[0], isLoading: false, error: null));
            var dispatcher = new ReduxDispatcher<AppState, Reducer>(
                initialState: appState,
                reducer: new Reducer(),
                notificationScheduler: TaskScheduler.Current);

            var serviceProvider = new BrowserServiceProvider(configure =>
            {
                configure.AddSingleton<IReduxDispatcher>(dispatcher);
                configure.AddSingleton<IReduxDispatcher<AppState>>(dispatcher);
                configure.AddSingleton<Communicator>();
            });
            dispatcher.Start();

            new BrowserRenderer(serviceProvider).AddComponent<Main>("app");
        }
    }
}
