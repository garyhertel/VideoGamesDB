using Avalonia;
using OxyPlot.Avalonia;

namespace VideoGamesDB.Start.Avalonia;

class Program
{
	static int Main(string[] args)
	{
		OxyPlotModule.EnsureLoaded();
		AppBuilder builder = BuildAvaloniaApp();

		return builder.StartWithClassicDesktopLifetime(args);
	}

	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.WithInterFont()
			.LogToTrace();
}
