using Atlas.Core;
using Atlas.Tabs;
using Atlas.Tabs.Test;
using Atlas.Tabs.Tools;
using Atlas.UI.Avalonia.Controls;

namespace VideoGamesDB.Tabs;

public class TabVideoGamesDB : ITab
{
	public TabInstance Create() => new Instance();

	public class Instance : TabInstance
	{
		public Database? Database;

		public override void Load(Call call, TabModel model)
		{
			LoadDatabase(call);

			model.Items = new List<ListItem>()
			{
				//new("Platforms", new TabPlatforms()),
				new("Database", new TabDatabase(Database!)),
				new("Charts", new TabVideoGameCharts(Database!)),
				new("Links", new TabBookmarks(Project)),
				new("Settings", new TabAvaloniaSettings()),
				new("Test", new TabTest()),
			};
		}

		private void LoadDatabase(Call call)
		{
			Database = new Database();
			var view = new ReleaseData.View();
			view.Load(call);
			Database.Load(view.Items);
		}
	}
}
