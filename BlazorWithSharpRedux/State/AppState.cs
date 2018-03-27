using Righthand.Immutable;

namespace BlazorWithSharpRedux.State
{
    public readonly struct AppState
    {
        public int Counter { get; }
        public AppState(int counter)
        {
            Counter = counter;
        }
        public AppState Clone(Param<int>? counter = null)
        {
            return new AppState(counter.HasValue ? counter.Value.Value : Counter);
        }
    }
}
