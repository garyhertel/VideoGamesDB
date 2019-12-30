using System;
using System.Collections.Generic;
using Atlas.Core;
using Atlas.Tabs;
using Atlas.Tabs.Test;

namespace VideoGamesDB.Tabs
{
	public class TabVideoGameCharts : ITab
	{
		private Database database;

		public TabVideoGameCharts(Database database)
		{
			this.database = database;
		}

		public TabInstance Create() { return new Instance(this); }

		public class Instance : TabInstance
		{
			private TabVideoGameCharts tab;

			public Instance(TabVideoGameCharts tab)
			{
				this.tab = tab;
			}

			public override void Load(Call call)
			{
				tabModel.Items = new ItemCollection<ListItem>()
				{
					new ListItem("Platforms", GetPlatformChart()),
					new ListItem("Publisher", GetPublisherChart()),
				};
			}

			private object GetPlatformChart()
			{
				var listGroup = new ListGroup("Sales by Platform")
				{
					xBinSize = 1,
				};
				listGroup.AddDimensions(tab.database.ReleaseViews, nameof(ReleaseView.Platform), nameof(ReleaseView.YearOfRelease), nameof(ReleaseView.Global_Sales));

				var chartSettings = new ChartSettings();
				chartSettings.AddGroup(listGroup);
				TabModel tabModel = new TabModel();
				tabModel.AddObject(chartSettings);
				return tabModel;
			}

			private object GetPublisherChart()
			{
				var listSeries = new ListSeries("Sales", tab.database.ReleaseViews, nameof(ReleaseView.YearOfRelease), nameof(ReleaseView.Global_Sales))
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
