using Atlas.Core;
using Atlas.Tabs;

namespace VideoGamesDB.Tabs;

public class TabDatabase : ITab
{
	public Database Database;

	public TabDatabase(Database database)
	{
		Database = database;
	}

	public TabInstance Create() => new Instance(this);

	public class Instance : TabInstance
	{
		public TabDatabase Tab;

		public Instance(TabDatabase tab)
		{
			Tab = tab;
		}

		public override void Load(Call call, TabModel model)
		{
			model.AddData(Tab.Database);

			/*model.Items = new ItemCollection<ListItem>()
			{
				//new ListItem("Platforms", new TabPlatforms()),
				new ListItem("Database", database),
			};*/
		}
	}
}
