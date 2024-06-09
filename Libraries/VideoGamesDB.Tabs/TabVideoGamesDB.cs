using Atlas.Core;
using Atlas.Tabs;
using Atlas.Tabs.Samples;
using Atlas.UI.Avalonia.Tabs;

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
				new("Samples", new TabSamples()),
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
