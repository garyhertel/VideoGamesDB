using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using OxyPlot.Avalonia;

namespace VideoGamesDB.Start.Avalonia
{
	class Program
	{
		static void Main(string[] args)
		{
			OxyPlotModule.EnsureLoaded();
			AppBuilder builder = BuildAvaloniaApp();

			builder.Start<MainWindow>();
		}

		public static AppBuilder BuildAvaloniaApp()
			=> AppBuilder.Configure<App>()
				.UsePlatformDetect()
				.LogToDebug();
	}
}
