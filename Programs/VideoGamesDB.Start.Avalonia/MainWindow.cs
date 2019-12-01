using Atlas.Tabs;
using Atlas.GUI.Avalonia;
using VideoGamesDB.Tabs;

namespace VideoGamesDB.Start.Avalonia
{
	public class MainWindow : BaseWindow
	{
		public MainWindow() : base(LoadProject())
		{
			AddClipBoardButtons();

			AddTabView(new TabVideoGamesDB());
		}

		public static Project LoadProject()
		{
			var projectSettings = new ProjectSettings()
			{
				Name = "VideoGamesDB",
				Version = "1",
				DataVersion = "1",
				LinkType = "atlas",
			};
			var userSettings = new UserSettings()
			{
				ProjectPath = UserSettings.DefaultProjectPath,
			};
			Project project = new Project(projectSettings, userSettings);
			return project;

			//Project project = new Project(projectPath, typeof(MainWindow).Namespace);
		}
	}
}