using Microsoft.AspNetCore.Components;
using ProgrammingCodePro.Service.Another;

namespace ProgrammingCodePro.Pages.Auth
{
    public partial class Auth
    {
        [Inject]
        private AuthService AuthService { get; set; } = null!;

        protected override void OnInitialized()
        {
            AuthService.ChangeAuth += StateHasChanged;
        }
        public void Dispose()
        {
            AuthService.ChangeAuth -= StateHasChanged;
        }
    }
}