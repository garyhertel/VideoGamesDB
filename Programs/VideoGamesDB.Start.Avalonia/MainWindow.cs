using Atlas.Tabs;
using Atlas.UI.Avalonia;
using Atlas.UI.Avalonia.Charts;
using Atlas.UI.Avalonia.ScreenCapture;
using VideoGamesDB.Tabs;

namespace VideoGamesDB.Start.Avalonia;

public class MainWindow : BaseWindow
{
	public MainWindow() : base(new Project(Settings))
	{
		AddTab(new TabVideoGamesDB());

		ChartGroupControl.Register();
		ScreenCapture.AddControlTo(TabViewer);
	}

	public static ProjectSettings Settings => new()
	{
		Name = "VideoGamesDB",
		LinkType = "VideoGamesDB",
		Version = new Version(1, 0),
		DataVersion = new Version(1, 0),
	};
}
