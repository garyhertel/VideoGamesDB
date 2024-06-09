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
		private Database? _database;

		public override void Load(Call call, TabModel model)
		{
			LoadDatabase(call);

			model.Items = new List<ListItem>()
			{
				//new("Platforms", new TabPlatforms()),
				new("Database", new TabDatabase(_database!)),
				new("Charts", new TabVideoGameCharts(_database!)),
				new("Links", new TabBookmarks(Project)),
				new("Settings", new TabAvaloniaSettings()),
				new("Samples", new TabSamples()),
			};
		}

		private void LoadDatabase(Call call)
		{
			_database = new Database();
			var view = new ReleaseData.View();
			view.Load(call);
			_database.Load(view.Items);
		}
	}
}
