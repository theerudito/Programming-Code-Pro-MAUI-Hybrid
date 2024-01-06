using Blazorise;
using Blazorise.Bootstrap;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Service.Another;
using ProgrammingCodePro.Service.Interface;
using ProgrammingCodePro.Service.Repository;
using ProgrammingCodePro.Services.Another;
using ProgrammingCodePro.Services.Repository;

namespace ProgrammingCodePro
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Services
			 .AddBlazorise(options =>
			 {
				 options.Immediate = true;
			 })
			 .AddBootstrapProviders();

			builder.Services.AddSingleton<LanguageService>();
			builder.Services.AddSingleton<ThemeService>();
			builder.Services.AddSingleton<InternetService>();

			builder.Services.AddSingleton<IAuth, AuthRepository>();
			builder.Services.AddSingleton<IMenu, MenuRepository>();
			builder.Services.AddSingleton<ICourse, CourseRepository>();
			builder.Services.AddSingleton<IMyApplication, ApplicationRepository>();

			builder.Services.AddSingleton<CourseTypesRepository>();
			builder.Services.AddSingleton<AuthService>();
			builder.Services.AddSingleton<ImagesCoursesRepository>();
			builder.Services.AddSingleton<ImagesClassRepository>();
			builder.Services.AddSingleton<DataUserRepository>();
			builder.Services.AddSingleton<MyClassRepository>();
			builder.Services.AddSingleton<My_Class_Repository>();

			builder.Services.AddSingleton<ApiManager>();
			builder.Services.AddTransient<MainPage>();

			builder.Services.AddMauiBlazorWebView();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}