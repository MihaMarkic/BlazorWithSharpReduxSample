using Righthand.Immutable;

namespace BlazorWithSharpRedux.State
{
    public readonly struct AppState
    {
        public CounterState Counter { get; }
        public FetchDataState FetchData { get; }

        public AppState(CounterState counter, FetchDataState fetchData)
        {
            Counter = counter;
            FetchData = fetchData;
        }

        public AppState Clone(Param<CounterState>? counter = null, Param<FetchDataState>? fetchData = null)
        {
            return new AppState(counter.HasValue ? counter.Value.Value : Counter,
fetchData.HasValue ? fetchData.Value.Value : FetchData);
        }
    }
}
