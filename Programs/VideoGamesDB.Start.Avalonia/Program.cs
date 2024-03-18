using Avalonia;
using Avalonia.Data.Core.Plugins;

namespace VideoGamesDB.Start.Avalonia;

class Program
{
	static int Main(string[] args)
	{
		// Remove Default DataAnnotations Validators
		// These validators show before values are entered, which ends up showing too many initial warnings
		// https://docs.avaloniaui.net/docs/data-binding/data-validation
		// Add custom template?
		BindingPlugins.DataValidators.RemoveAt(0);

		AppBuilder builder = BuildAvaloniaApp();

		return builder.StartWithClassicDesktopLifetime(args);
	}

	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.WithInterFont()
			.LogToTrace();
}
