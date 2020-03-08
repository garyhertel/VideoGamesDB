using Atlas.Tabs;
using Atlas.GUI.Avalonia;
using VideoGamesDB.Tabs;
using System;

namespace VideoGamesDB.Start.Avalonia
{
	public class MainWindow : BaseWindow
	{
		public MainWindow() : base(LoadProject())
		{
			AddTab(new TabVideoGamesDB());
		}

		public static Project LoadProject()
		{
			var projectSettings = new ProjectSettings()
			{
				Name = "VideoGamesDB",
				LinkType = "atlas",
				Version = new Version(1, 0),
				DataVersion = new Version(1, 0),
			};
			var userSettings = new UserSettings()
			{
				ProjectPath = UserSettings.DefaultProjectPath,
			};
			Project project = new Project(projectSettings, userSettings);
			return project;
		}
	}
}