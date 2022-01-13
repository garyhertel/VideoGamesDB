using Atlas.Core;
using Atlas.Tabs;
using System.Collections.Generic;

namespace VideoGamesDB.Tabs;

public class TabVideoGameCharts : ITab
{
	public Database Database;

	public TabVideoGameCharts(Database database)
	{
		Database = database;
	}

	public TabInstance Create() => new Instance(this);

	public class Instance : TabInstance
	{
		private readonly TabVideoGameCharts Tab;

		public Instance(TabVideoGameCharts tab)
		{
			Tab = tab;
		}

		public override void Load(Call call, TabModel model)
		{
			model.Items = new List<ListItem>()
			{
				new("Platforms", GetPlatformChart()),
				new("Publisher", GetPublisherChart()),
				new("Developer", GetDeveloperChart()),
				new("Sales", GetSalesChart()),
			};
		}

		private object GetPlatformChart()
		{
			var listGroup = new ListGroup("Sales by Platform")
			{
				XBinSize = 1,
			};
			listGroup.AddDimensions(Tab.Database.ReleaseViews,
				nameof(ReleaseView.Platform),
				nameof(ReleaseView.YearOfRelease),
				nameof(ReleaseView.Global_Sales));

			var chartSettings = new ChartSettings(listGroup);
			var model = new TabModel()
			{
				MinDesiredWidth = 1000,
			};
			model.AddObject(chartSettings);
			return model;
		}

		private object GetPublisherChart()
		{
			var listGroup = new ListGroup("Sales by Publisher")
			{
				XBinSize = 1,
			};
			listGroup.AddDimensions(Tab.Database.ReleaseViews,
				nameof(ReleaseView.Publisher),
				nameof(ReleaseView.YearOfRelease),
				nameof(ReleaseView.Global_Sales));

			var chartSettings = new ChartSettings(listGroup);
			var model = new TabModel()
			{
				MinDesiredWidth = 1000,
			};
			model.AddObject(chartSettings);
			return model;
		}

		private object GetDeveloperChart()
		{
			var listGroup = new ListGroup("Sales by Developer")
			{
				XBinSize = 1,
			};
			listGroup.AddDimensions(Tab.Database.ReleaseViews,
				nameof(ReleaseView.Developer),
				nameof(ReleaseView.YearOfRelease),
				nameof(ReleaseView.Global_Sales));

			var chartSettings = new ChartSettings(listGroup);
			var model = new TabModel()
			{
				MinDesiredWidth = 1000,
			};
			model.AddObject(chartSettings);
			return model;
		}

		private object GetSalesChart()
		{
			var listSeries = new ListSeries("Sales", Tab.Database.ReleaseViews, nameof(ReleaseView.YearOfRelease), nameof(ReleaseView.Global_Sales))
			{
				XBinSize = 1,
				// Dimensions, allow selecting multiple
				//yPropertyName = nameof(ReleaseData.Platform),
				//yPropertyName = nameof(ReleaseData.Genre),
				//yPropertyName = nameof(ReleaseData.Publisher),
				//yPropertyName = nameof(ReleaseData.Developer),
			};
			var chartSettings = new ChartSettings();
			chartSettings.AddSeries(listSeries);
			//return chartSettings;
			var model = new TabModel()
			{
				MinDesiredWidth = 1000,
			};
			model.AddObject(chartSettings);
			return model;
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
