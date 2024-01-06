using Microsoft.AspNetCore.Components;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Service.Another;
using ProgrammingCodePro.Services.Repository;

namespace ProgrammingCodePro.Pages.About
{
	public partial class About
	{
		private string IdUser;

		[Inject]
		private DataUserRepository DataUserRepository { get; set; } = null!;

		[Inject]
		private LanguageService LanguageService { get; set; } = null!;

		[Inject]
		private ThemeService ThemeService { get; set; } = null!;

		[Inject]
		private NavigationManager Navigation { get; set; } = null!;

		protected override async Task OnInitializedAsync()
		{
			IdUser = await LocalStorageDataApp.GetItem(LocalStorageDataApp.KeyIdUser);
			LanguageService.ChangeLanguage += StateHasChanged;
			ThemeService.ChangeTheme += StateHasChanged;
		}

		public async void DeleteAccount()
		{
			if (MyVariablesApp._languageApp == "EN"
				 ? await App.Current.MainPage.DisplayAlert("Programming Code", "Are you sure you want to delete your account, this is unacceptable?", "YES", "NO")
				 : await App.Current.MainPage.DisplayAlert("Programming Code", "Estas Seguro que quieres borrar tu cuenta esto es irrebesible?", "SI", "NO"))
			{
				LocalStorageDataApp.RemoveItem();
				await DataUserRepository.DeleteDataUser(Convert.ToInt32(IdUser));
				NavigationManagerApp._inHome = false;
				Navigation.NavigateTo("/auth");
			}
			else
			{
				return;
			}
		}

		public void Dispose()
		{
			LanguageService.ChangeLanguage -= StateHasChanged;
			ThemeService.ChangeTheme += StateHasChanged;
		}
	}
}