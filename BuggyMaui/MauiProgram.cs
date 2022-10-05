using BuggyMaui.ViewModels;
using BuggyMaui.Views;
using MetroLog.MicrosoftExtensions;

namespace BuggyMaui;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// configure logging
		builder.Logging.AddTraceLogger(options => { });

		// add connectivity for the viewmodels
		builder.Services.AddSingleton((e) => Connectivity.Current);

		// include the viewmodels as a service
		builder.Services.AddTransient<ResultsViewModel>();
        builder.Services.AddTransient<ReviewViewModel>();
        builder.Services.AddTransient<SuccessViewModel>();

        // link pages in with the viewmodels
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ResultsPage>();
        builder.Services.AddTransient<ReviewPage>();
        builder.Services.AddTransient<SuccessPage>();

        return builder.Build();
	}
}
