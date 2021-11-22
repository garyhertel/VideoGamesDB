using Atlas.Core;
using Atlas.Extensions;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VideoGamesDB.Tabs
{
	public class ReleaseData
	{
		public string Name { get; set; }
		public string Platform { get; set; }
		public string Year_of_Release { get; set; } // can be "N/A"
		public string Genre { get; set; }
		public string Publisher { get; set; }
		public string Developer { get; set; }

		public double Global_Sales { get; set; }
		public double NA_Sales { get; set; }
		public double EU_Sales { get; set; }
		public double JP_Sales { get; set; }
		public double Other_Sales { get; set; }

		public int? Critic_Score { get; set; }
		public int? Critic_Count { get; set; }

		public string User_Score { get; set; }
		public int? User_Count { get; set; }

		public string Rating { get; set; }

		public override string ToString() => Name;

		public class View
		{
			public const string ZipFilename = "video-game-sales-with-ratings.zip";
			public const string Filename = "Assets/Video_Games_Sales_as_at_22_Dec_2016.csv";

			public List<ReleaseData> Items { get; set; } = new List<ReleaseData>();

			public override string ToString() => Items.Formatted();

			public void Load(Call call)
			{
				using (var reader = new StreamReader(Filename))
				using (var csv = new CsvReader(reader))
				{
					Items = csv.GetRecords<ReleaseData>().ToList();
				}
			}
		}
	}
}
