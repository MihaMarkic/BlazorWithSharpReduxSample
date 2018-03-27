using BlazorWithSharpRedux.State;
using Sharp.Redux;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorWithSharpRedux.Services
{
    public class Reducer : IReduxReducer<AppState>
    {
        readonly CounterReducer counterReducer = new CounterReducer();
        public async Task<AppState> ReduceAsync(AppState state, ReduxAction action, CancellationToken ct)
        {
            var counter = await counterReducer.ReduceAsync(state.Counter, action, ct);
            return state.Clone(counter);
        }
    }
}
