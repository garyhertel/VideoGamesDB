using Atlas.Tabs;
using Atlas.GUI.Avalonia;
using VideoGamesDB.Tabs;

namespace VideoGamesDB.Start.Avalonia
{
	public class MainWindow : BaseWindow
	{
		public MainWindow() : base()
		{
			LoadProject(ProjectSettings.DefaultProjectPath);
		}

		public void LoadProject(string projectPath)
		{
			Project project = new Project(projectPath, typeof(MainWindow).Namespace);

			LoadProject(project);
			AddClipBoardButtons();

			AddTabView(new TabVideoGamesDB.Instance(project));
		}
	}
}