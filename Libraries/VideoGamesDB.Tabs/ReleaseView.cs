
namespace VideoGamesDB.Tabs
{
	public class ReleaseView
	{
		public ReleaseData releaseData;

		public GameTitle Title { get; set; }
		public Platform Platform { get; set; } // use serializer converters instead?
		public Genre Genre { get; set; }
		public Publisher Publisher { get; set; }
		public Developer Developer { get; set; }

		public string Name => releaseData.Name;
		public int? YearOfRelease { get; set; }
		public decimal Global_Sales => releaseData.Global_Sales;
		public decimal NA_Sales => releaseData.NA_Sales;
		public decimal EU_Sales => releaseData.EU_Sales;
		public decimal JP_Sales => releaseData.JP_Sales;
		public decimal Other_Sales => releaseData.Other_Sales;
		public int? Critic_Score => releaseData.Critic_Score;
		public int? Critic_Count => releaseData.Critic_Count;
		public string User_Score => releaseData.User_Score;
		public int? User_Count => releaseData.User_Count;
		public string Rating => releaseData.Rating;



		public ReleaseView()
		{
		}

		// todo: add a new Serializer Clone to SubType method?
		// use property links without subtype instead?
		public ReleaseView(ReleaseData releaseData)
		{
			this.releaseData = releaseData;

			if (int.TryParse(releaseData.Year_of_Release, out int year))
				YearOfRelease = year;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
