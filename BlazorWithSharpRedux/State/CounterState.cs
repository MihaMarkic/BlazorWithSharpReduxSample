using Righthand.Immutable;

namespace BlazorWithSharpRedux.State
{
    public readonly struct CounterState
    {
        public int Value { get; }

        public CounterState(int value)
        {
            Value = value;
        }

        public CounterState Clone(Param<int>? value = null)
        {
            return new CounterState(value.HasValue ? value.Value.Value : Value);
        }
    }
}
