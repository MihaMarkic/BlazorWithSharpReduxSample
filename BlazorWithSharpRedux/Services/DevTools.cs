using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace BlazorWithSharpRedux.Services
{
    public static class DevTools
    {
        public static bool AreAvailable()
        {
            return RegisteredFunction.Invoke<bool>("DevToools.AreAvailable");
        }
        public static void Init(object state)
        {
            RegisteredFunction.Invoke<object>("DevToools.Init", state);
        }
        public static void Send(object action, object state)
        {
            RegisteredFunction.Invoke<object>("DevToools.Send", action, state);
        }
    }
}
