using System.Threading;
using System.Threading.Tasks;
using BlazorWithSharpRedux.Actions;
using BlazorWithSharpRedux.State;
using Sharp.Redux;

namespace BlazorWithSharpRedux.Reducers
{
    public class CounterReducer : IReduxReducer<CounterState>
    {
        public Task<CounterState> ReduceAsync(CounterState state, ReduxAction action, CancellationToken ct)
        {
            switch (action)
            {
                case IncrementCounterAction incrementCounter:
                    return Task.FromResult(state.Clone(value: state.Value + 1));
                default:
                    return Task.FromResult(state);
            }
        }
    }
}
