using Sharp.Redux;

namespace BlazorWithSharpRedux.Actions
{
    public abstract class BlazorReduxAction: ReduxAction
    {
        public string type => GetType().Name;
    }
}
