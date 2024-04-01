using Atlas.Core;
using Atlas.Tabs;

namespace VideoGamesDB.Tabs;

public class TabDatabase(Database database) : ITab
{
	public Database Database = database;

	public TabInstance Create() => new Instance(this);

	public class Instance(TabDatabase tab) : TabInstance
	{
		public TabDatabase Tab = tab;

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
