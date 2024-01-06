using Microsoft.AspNetCore.Components;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Service.Another;

namespace ProgrammingCodePro.Pages.Header
{
    public partial class Header
    {
        private string _nameUser;

        [Inject]
        private LanguageService LanguageService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            LanguageService.ChangeLanguage += StateHasChanged;

            _nameUser = await LocalStorageDataApp.GetItem(LocalStorageDataApp.KeyUser);

            StateHasChanged();
        }
    }
}
