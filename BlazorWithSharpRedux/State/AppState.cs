using Righthand.Immutable;

namespace BlazorWithSharpRedux.State
{
    public class AppState
    {
        public  static AppState Current { get; set; }
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
