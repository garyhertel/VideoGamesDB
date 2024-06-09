using Atlas.Core;
using Atlas.Core.Charts;
using Atlas.Tabs;

namespace VideoGamesDB.Tabs;

public class TabVideoGameCharts(Database database) : ITab
{
	public Database Database = database;

	public TabInstance Create() => new Instance(this);

	public class Instance(TabVideoGameCharts tab) : TabInstance
	{
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
			var chartView = new ChartView("Sales by Platform")
			{
				XBinSize = 1,
			};
			chartView.AddDimensions(tab.Database.ReleaseViews,
				nameof(ReleaseView.YearOfRelease),
				nameof(ReleaseView.Global_Sales),
				nameof(ReleaseView.Platform));

			var model = new TabModel()
			{
				MinDesiredWidth = 1000,
			};
			model.AddObject(chartView);
			return model;
		}

		private object GetPublisherChart()
		{
			var chartView = new ChartView("Sales by Publisher")
			{
				XBinSize = 1,
			};
			chartView.AddDimensions(tab.Database.ReleaseViews,
				nameof(ReleaseView.YearOfRelease),
				nameof(ReleaseView.Global_Sales),
				nameof(ReleaseView.Publisher));

			var model = new TabModel()
			{
				MinDesiredWidth = 1000,
			};
			model.AddObject(chartView);
			return model;
		}

		private object GetDeveloperChart()
		{
			var chartView = new ChartView("Sales by Developer")
			{
				XBinSize = 1,
			};
			chartView.AddDimensions(tab.Database.ReleaseViews,
				nameof(ReleaseView.YearOfRelease),
				nameof(ReleaseView.Global_Sales),
				nameof(ReleaseView.Developer));

			var model = new TabModel()
			{
				MinDesiredWidth = 1000,
			};
			model.AddObject(chartView);
			return model;
		}

		private object GetSalesChart()
		{
			var listSeries = new ListSeries("Sales", tab.Database.ReleaseViews, nameof(ReleaseView.YearOfRelease), nameof(ReleaseView.Global_Sales))
			{
				XBinSize = 1,
				// Dimensions, allow selecting multiple
				//yPropertyName = nameof(ReleaseData.Platform),
				//yPropertyName = nameof(ReleaseData.Genre),
				//yPropertyName = nameof(ReleaseData.Publisher),
				//yPropertyName = nameof(ReleaseData.Developer),
			};
			var chartView = new ChartView();
			chartView.Series.Add(listSeries);
			//return chartSettings;
			var model = new TabModel()
			{
				MinDesiredWidth = 1000,
			};
			model.AddObject(chartView);
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
