
using Atlas.Core;

namespace VideoGamesDB.Tabs;

public class ReleaseView
{
	public ReleaseData ReleaseData;

	[AutoSize]
	public GameTitle Title { get; set; }
	public Platform Platform { get; set; } // use serializer converters instead?
	public Genre Genre { get; set; }
	public Publisher Publisher { get; set; }
	public Developer Developer { get; set; }

	public string Name => ReleaseData.Name;
	public int? YearOfRelease { get; set; }
	public double Global_Sales => ReleaseData.Global_Sales * 1000000;
	public double NA_Sales => ReleaseData.NA_Sales * 1000000;
	public double EU_Sales => ReleaseData.EU_Sales * 1000000;
	public double JP_Sales => ReleaseData.JP_Sales * 1000000;
	public double Other_Sales => ReleaseData.Other_Sales * 1000000;
	public int? Critic_Score => ReleaseData.Critic_Score;
	public int? Critic_Count => ReleaseData.Critic_Count;
	public string User_Score => ReleaseData.User_Score;
	public int? User_Count => ReleaseData.User_Count;
	public string Rating => ReleaseData.Rating;

	public override string ToString() => Name;

	public ReleaseView()
	{
	}

	// todo: add a new Serializer Clone to SubType method?
	// use property links without subtype instead?
	public ReleaseView(ReleaseData releaseData)
	{
		ReleaseData = releaseData;

		if (int.TryParse(releaseData.Year_of_Release, out int year))
			YearOfRelease = year;
	}
}
