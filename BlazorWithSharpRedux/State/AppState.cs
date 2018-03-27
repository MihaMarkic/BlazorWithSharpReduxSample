using Righthand.Immutable;

namespace BlazorWithSharpRedux.State
{
    public readonly struct AppState
    {
        public CounterState Counter { get; }

        public AppState(CounterState counter)
        {
            Counter = counter;
        }

        public AppState Clone(Param<CounterState>? counter = null)
        {
            return new AppState(counter.HasValue ? counter.Value.Value : Counter);
        }
    }
}
