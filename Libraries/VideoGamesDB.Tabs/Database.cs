using Atlas.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoGamesDB.Tabs;

public class Database
{
	public List<GameTitle> Games { get; set; } = new();
	[HiddenRow]
	public SortedDictionary<string, GameTitle> IdxGameNames { get; set; } = new();

	public List<ReleaseData> ReleaseDatas { get; set; } = new();

	public List<ReleaseView> ReleaseViews { get; set; } = new();

	public List<Platform> Platforms { get; set; } = new();
	[HiddenRow]
	public SortedDictionary<string, Platform> IdxPlatformNames { get; set; } = new();

	public List<Genre> Genres { get; set; } = new();
	[HiddenRow]
	public Dictionary<string, Genre> IdxGenreNames { get; set; } = new();

	public List<Publisher> Publishers { get; set; } = new();
	[HiddenRow]
	public SortedDictionary<string, Publisher> IdxPublisherNames { get; set; } = new();

	public List<Developer> Developers { get; set; } = new();
	[HiddenRow]
	public SortedDictionary<string, Developer> IdxDeveloperNames { get; set; } = new();

	public void Load(List<ReleaseData> Items)
	{
		ReleaseDatas = Items;
		foreach (ReleaseData releaseData in Items)
		{
			var releaseView = new ReleaseView(releaseData);
			ReleaseViews.Add(releaseView);

			Platform platform = AddPlatform(releaseView);
			GameTitle gameTitle = AddTitle(releaseView);
			Publisher publisher = AddPublisher(releaseView);
			Developer developer = AddDeveloper(releaseView);
			Genre genre = AddGenre(releaseView);

			//if (!IdxGameName.ContainsKey(releaseData.Name))
			//	IdxGameName.Add(releaseData.Name, releaseData);

			publisher.Titles.Add(gameTitle);
			developer.Titles.Add(gameTitle);
			genre.Titles.Add(gameTitle);
		}

		ReleaseDatas = ReleaseDatas.OrderBy(g => g.Name).ToList();
		ReleaseViews = ReleaseViews.OrderBy(g => g.Name).ToList();
		Platforms = Platforms.OrderBy(g => g.Name).ToList();
		Genres = Genres.OrderBy(g => g.Name).ToList();
		Developers = Developers.OrderBy(g => g.Name).ToList();
		Publishers = Publishers.OrderBy(g => g.Name).ToList();
		Games = Games.OrderBy(g => g.Name).ToList();
	}

	private Platform AddPlatform(ReleaseView releaseView)
	{
		string platformName = releaseView.ReleaseData.Platform;
		if (!IdxPlatformNames.TryGetValue(platformName, out Platform platform))
		{
			platform = new Platform()
			{
				Name = platformName,
			};
			IdxPlatformNames.Add(platformName, platform);
			Platforms.Add(platform);
		}
		if (!platform.Releases.ContainsKey(releaseView.Name))
			platform.Releases.Add(releaseView.Name, releaseView);
		releaseView.Platform = platform;
		return platform;
	}

	private GameTitle AddTitle(ReleaseView releaseView)
	{
		if (!IdxGameNames.TryGetValue(releaseView.Name, out GameTitle gameTitle))
		{
			gameTitle = new GameTitle()
			{
				Name = releaseView.Name,
			};
			IdxGameNames.Add(releaseView.Name, gameTitle);
			Games.Add(gameTitle);
		}
		gameTitle.Releases.Add(releaseView);
		releaseView.Title = gameTitle;
		return gameTitle;
	}

	private Publisher AddPublisher(ReleaseView releaseView)
	{
		if (!IdxPublisherNames.TryGetValue(releaseView.ReleaseData.Publisher, out Publisher publisher))
		{
			publisher = new Publisher()
			{
				Name = releaseView.ReleaseData.Publisher,
			};
			IdxPublisherNames.Add(publisher.Name, publisher);
			Publishers.Add(publisher);
		}
		publisher.Releases.Add(releaseView);
		releaseView.Publisher = publisher;
		return publisher;
	}

	private Developer AddDeveloper(ReleaseView releaseView)
	{
		if (!IdxDeveloperNames.TryGetValue(releaseView.ReleaseData.Developer, out Developer developer))
		{
			developer = new Developer()
			{
				Name = releaseView.ReleaseData.Developer,
			};
			IdxDeveloperNames.Add(developer.Name, developer);
			Developers.Add(developer);
		}
		developer.Releases.Add(releaseView);
		releaseView.Developer = developer;
		return developer;
	}

	private Genre AddGenre(ReleaseView releaseView)
	{
		if (!IdxGenreNames.TryGetValue(releaseView.ReleaseData.Genre, out Genre genre))
		{
			genre = new Genre()
			{
				Name = releaseView.ReleaseData.Genre,
			};
			IdxGenreNames.Add(genre.Name, genre);
			Genres.Add(genre);
		}
		genre.Releases.Add(releaseView);
		releaseView.Genre = genre;
		return genre;
	}
}

public class Platform
{
	public string Name { get; set; }
	[Hidden]
	public SortedDictionary<string, ReleaseView> Releases { get; set; } = new();
	public List<ReleaseView> Items => Releases.Values.ToList();

	public override string ToString() => Name;
}

public class GameTitle
{
	public string Name { get; set; }
	public List<ReleaseView> Releases { get; set; } = new();

	public override string ToString() => Name;
}

public class Publisher
{
	public string Name { get; set; }
	public HashSet<GameTitle> Titles { get; set; } = new();
	public List<ReleaseView> Releases { get; set; } = new();

	public override string ToString() => Name;
}

public class Developer
{
	public string Name { get; set; }
	public HashSet<GameTitle> Titles { get; set; } = new();
	public List<ReleaseView> Releases { get; set; } = new();

	public override string ToString() => Name;
}

public class Genre
{
	public string Name { get; set; }
	public HashSet<GameTitle> Titles { get; set; } = new();
	public List<ReleaseView> Releases { get; set; } = new();

	public override string ToString() => Name;
}
