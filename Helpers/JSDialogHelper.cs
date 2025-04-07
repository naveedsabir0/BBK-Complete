using Microsoft.JSInterop;

namespace MovieDatabaseBlazorServerApp.Helpers
{
    public static class JSDialogHelper
    {
        public static async Task Alert(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("alert", message);
        }

        public static async Task<bool> Confirm(this IJSRuntime js, string message)
        {
            return await js.InvokeAsync<bool>("confirm", message);
        }

        public static async Task<string> Prompt(this IJSRuntime js, string message)
        {
            return await js.InvokeAsync<string>("prompt", message);
        }
    }
}
