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
			public Database database;

			public override void Load(Call call)
			{
				LoadDatabase();

				tabModel.Items = new ItemCollection<ListItem>()
				{
					//new ListItem("Platforms", new TabPlatforms()),
					new ListItem("Database", new TabDatabase(database)),
					new ListItem("Charts", GetPublisherChart()),
					new ListItem("Test", new TabTest()),
				};
			}

			private void LoadDatabase()
			{
				database = new Database();
				var view = new ReleaseData.View();
				view.Load(taskInstance.call);
				database.Load(view.Items);
			}

			private object GetPublisherChart()
			{
				var listSeries = new ListSeries("Sales", database.ReleaseViews, nameof(ReleaseView.YearOfRelease), nameof(ReleaseView.Global_Sales))
				{
					xBinSize = 1,
					// Dimensions, allow selecting multiple
					//yPropertyName = nameof(ReleaseData.Platform),
					//yPropertyName = nameof(ReleaseData.Genre),
					//yPropertyName = nameof(ReleaseData.Publisher),
					//yPropertyName = nameof(ReleaseData.Developer),
				};
				var chartSettings = new ChartSettings();
				chartSettings.AddSeries(listSeries);
				//return chartSettings;
				TabModel tabModel = new TabModel();
				tabModel.AddObject(chartSettings);
				return tabModel;
			}
		}
	}
}

/*

Charts
	Sales by platform
	Sales by publisher
	Sales by publisher & platform
	Sales by region
	User Score per 
*/
