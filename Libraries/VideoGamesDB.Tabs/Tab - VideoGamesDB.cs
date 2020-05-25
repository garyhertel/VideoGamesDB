using Atlas.Core;
using Atlas.Tabs;
using Atlas.Tabs.Test;

namespace VideoGamesDB.Tabs
{
	public class TabVideoGamesDB : ITab
	{
		public TabInstance Create() { return new Instance(); }

		public class Instance : TabInstance
		{
			public Database database;

			public override void Load(Call call, TabModel model)
			{
				LoadDatabase(call);

				model.Items = new ItemCollection<ListItem>()
				{
					//new ListItem("Platforms", new TabPlatforms()),
					new ListItem("Database", new TabDatabase(database)),
					new ListItem("Charts", new TabVideoGameCharts(database)),
					new ListItem("Test", new TabTest()),
				};
			}

			private void LoadDatabase(Call call)
			{
				database = new Database();
				var view = new ReleaseData.View();
				view.Load(call);
				database.Load(view.Items);
			}
		}
	}
}
