using System;
using System.Collections.Generic;
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
			public Database database = null;

			public Instance()
			{
			}

			public Instance(Project project)
			{
				this.project = project;
				LoadDefaultBookmark();

				tabModel.Name = "Video Games DB";

				tabModel.Bookmarks = new BookmarkCollection(project);
			}

			public override void Load(Call call)
			{
				ItemCollection<TaskCreator> actions = new ItemCollection<TaskCreator>();
				database = new Database();
				var view = new ReleaseData.View();
				view.Load(taskInstance.call);
				database.Load(view.Items);
				/*if (database == null)
				{
					actions.Add(new TaskDelegate("Load", LoadDatabase, true));
				}
				else*/
				{
					tabModel.Items = new ItemCollection<ListItem>()
					{
						//new ListItem("Platforms", new TabPlatforms()),
						new ListItem("Database", database),
						new ListItem("Test", new TabTest()),
					};
					//tabModel.AddObject(database);
					//tabModel.Items = database.Items;
				}
				tabModel.Actions = actions;
			}

			/*private void LoadDatabase(Call call)
			{
				database = new GameData.View();
				database.Load(call);
				Reload();
			}*/
		}
	}
}
