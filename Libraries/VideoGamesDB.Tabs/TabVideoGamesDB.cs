﻿using Atlas.Core;
using Atlas.Tabs;
using Atlas.Tabs.Test;
using Atlas.UI.Avalonia.Controls;

namespace VideoGamesDB.Tabs
{
	public class TabVideoGamesDB : ITab
	{
		public TabInstance Create() => new Instance();

		public class Instance : TabInstance
		{
			public Database Database;

			public override void Load(Call call, TabModel model)
			{
				LoadDatabase(call);

				model.Items = new ItemCollection<ListItem>()
				{
					//new ListItem("Platforms", new TabPlatforms()),
					new ListItem("Database", new TabDatabase(Database)),
					new ListItem("Charts", new TabVideoGameCharts(Database)),
					new ListItem("Bookmarks", new TabBookmarks(Project)),
					new ListItem("Test", new TabTest()),
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
}
