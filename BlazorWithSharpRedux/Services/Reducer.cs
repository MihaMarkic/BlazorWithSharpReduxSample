using Sharp.Redux;
using BlazorWithSharpRedux.Actions;
using BlazorWithSharpRedux.State;

namespace BlazorWithSharpRedux.Services
{
    public class Reducer : IReduxReducer<AppState>
    {
        public AppState Reduce(AppState state, ReduxAction action)
        {
            switch (action)
            {
                case IncrementCounterAction incrementCounter:
                    return state.Clone(counter: state.Counter + 1);
                default:
                    return state;
            }
        }
    }
}
