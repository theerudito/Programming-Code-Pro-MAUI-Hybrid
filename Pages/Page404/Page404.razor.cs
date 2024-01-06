using Microsoft.AspNetCore.Components;
using ProgrammingCodePro.Services.Another;

namespace ProgrammingCodePro.Pages.Page404
{
	public partial class Page404
	{
		[Inject]
		private InternetService InternetService { get; set; } = null!;

		protected override void OnInitialized()
		{
			InternetService.InternetChange += StateHasChanged;
		}

		public void Dispose()
		{
			InternetService.InternetChange -= StateHasChanged;
		}
	}
}