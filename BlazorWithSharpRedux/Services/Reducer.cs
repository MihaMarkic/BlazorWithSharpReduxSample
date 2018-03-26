using Sharp.Redux;
using BlazorWithSharpRedux.Actions;
using BlazorWithSharpRedux.State;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorWithSharpRedux.Services
{
    public class Reducer : IReduxReducer<AppState>
    {
        public Task<AppState> ReduceAsync(AppState state, ReduxAction action, CancellationToken ct)
        {
            switch (action)
            {
                case IncrementCounterAction incrementCounter:
                    return Task.FromResult(state.Clone(counter: state.Counter + 1));
                default:
                    return Task.FromResult(state);
            }
        }
    }
}
