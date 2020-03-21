using System;
using System.Collections.Generic;
using Atlas.Core;
using Atlas.Tabs;

namespace VideoGamesDB.Tabs
{
	public class TabDatabase : ITab
	{
		public Database database;

		public TabDatabase(Database database)
		{
			this.database = database;
		}

		public TabInstance Create() { return new Instance(this); }

		public class Instance : TabInstance
		{
			public TabDatabase tab;

			public Instance(TabDatabase tab)
			{
				this.tab = tab;
			}

			public override void Load(Call call, TabModel model)
			{
				model.AddData(tab.database);

				/*model.Items = new ItemCollection<ListItem>()
				{
					//new ListItem("Platforms", new TabPlatforms()),
					new ListItem("Database", database),
				};*/
			}
		}
	}
}
