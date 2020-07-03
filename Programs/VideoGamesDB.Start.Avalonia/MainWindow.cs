using Atlas.Tabs;
using Atlas.UI.Avalonia;
using VideoGamesDB.Tabs;
using System;

namespace VideoGamesDB.Start.Avalonia
{
	public class MainWindow : BaseWindow
	{
		public MainWindow() : base(new Project(Settings))
		{
			AddTab(new TabVideoGamesDB());
		}

		public static ProjectSettings Settings => new ProjectSettings()
		{
			Name = "VideoGamesDB",
			LinkType = "VideoGamesDB",
			Version = new Version(1, 0),
			DataVersion = new Version(1, 0),
		};
	}
}