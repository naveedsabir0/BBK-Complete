using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace MovieDatabaseBlazorServerApp.Components.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        [CascadingParameter]
        protected Task<AuthenticationState> AuthenticationStateTask { get; set; }

        protected ClaimsPrincipal? CurrentUser
        {
            get
            {
                var authState = AuthenticationStateTask.Result;
                var user = authState.User;
                return user;
            }
        }


        public string PageTitle { get; set; }
    }
}

