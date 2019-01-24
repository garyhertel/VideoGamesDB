
namespace VideoGamesDB.Tabs
{
	public class ReleaseView : ReleaseData
	{
		public ReleaseData releaseData;

		public GameTitle Title { get; set; }
		public new Platform Platform { get; set; } // use serializer converters instead?
		public new Genre Genre { get; set; }
		public new Publisher Publisher { get; set; }
		public new Developer Developer { get; set; }

		public ReleaseView()
		{
		}

		// todo: add a new Serializer Clone to SubType method?
		// use property links without subtype instead?
		public ReleaseView(ReleaseData releaseData)
		{
			this.releaseData = releaseData;

			this.Name = releaseData.Name;
			this.Year_of_Release = releaseData.Year_of_Release;
			this.Global_Sales = releaseData.Global_Sales;
			this.NA_Sales = releaseData.NA_Sales;
			this.EU_Sales = releaseData.EU_Sales;
			this.JP_Sales = releaseData.JP_Sales;
			this.Other_Sales = releaseData.Other_Sales;
			this.Critic_Score = releaseData.Critic_Score;
			this.Critic_Count = releaseData.Critic_Count;
			this.User_Score = releaseData.User_Score;
			this.User_Count = releaseData.User_Count;
			this.Rating = releaseData.Rating;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
