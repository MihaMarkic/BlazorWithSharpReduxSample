using BlazorWithSharpRedux.State;
using Sharp.Redux;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorWithSharpRedux.Reducers
{
    public class Reducer : IReduxReducer<AppState>
    {
        readonly CounterReducer counterReducer = new CounterReducer();
        readonly FetchDataReducer fetchDataReducer = new FetchDataReducer();
        public async Task<AppState> ReduceAsync(AppState state, ReduxAction action, CancellationToken ct)
        {
            var counter = await counterReducer.ReduceAsync(state.Counter, action, ct);
            var fetchData = await fetchDataReducer.ReduceAsync(state.FetchData, action, ct);
            return state.Clone(counter, fetchData);
        }
    }
}
