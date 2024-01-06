using Microsoft.AspNetCore.Components;
using ProgrammingCodePro.Service.Another;

namespace ProgrammingCodePro.Pages.Footer
{
    public partial class Footer
    {
        [Inject]
        private LanguageService LanguageService { get; set; } = null!;

        protected override void OnInitialized()
        {
            LanguageService.ChangeLanguage += StateHasChanged;
        }
    }
}
