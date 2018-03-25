using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using Sharp.Redux;
using System.Threading.Tasks;
using BlazorWithSharpRedux.Services;
using BlazorWithSharpRedux.State;

namespace BlazorWithSharpRedux
{
    class Program
    {
        static void Main(string[] args)
        {
            var appState = new AppState(0);
            AppState.Current = appState;
            var dispatcher = new ReduxDispatcher<AppState, Reducer>(
                initialState: appState,
                reducer: new Reducer(),
                notificationScheduler: TaskScheduler.Current);
            
            var serviceProvider = new BrowserServiceProvider(configure =>
            {
                configure.AddSingleton(dispatcher);
            });

            new BrowserRenderer(serviceProvider).AddComponent<Main>("app");
        }
    }
}
