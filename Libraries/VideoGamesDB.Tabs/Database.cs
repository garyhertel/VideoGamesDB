using Atlas.Core;
using Atlas.Extensions;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VideoGamesDB.Tabs
{
	public class Database
	{
		public List<GameTitle> Games { get; set; } = new List<GameTitle>();
		[HiddenRow]
		public Dictionary<string, GameTitle> IdxGameNames { get; set; } = new Dictionary<string, GameTitle>();

		public List<ReleaseData> ReleaseDatas { get; set; } = new List<ReleaseData>();

		public List<ReleaseView> ReleaseViews { get; set; } = new List<ReleaseView>();

		public List<Platform> Platforms { get; set; } = new List<Platform>();
		[HiddenRow]
		public Dictionary<string, Platform> IdxPlatformNames { get; set; } = new Dictionary<string, Platform>();

		public List<Genre> Genres { get; set; } = new List<Genre>();
		[HiddenRow]
		public Dictionary<string, Genre> IdxGenreNames { get; set; } = new Dictionary<string, Genre>();

		public List<Publisher> Publishers { get; set; } = new List<Publisher>();
		[HiddenRow]
		public Dictionary<string, Publisher> IdxPublisherNames { get; set; } = new Dictionary<string, Publisher>();

		public List<Developer> Developers { get; set; } = new List<Developer>();
		[HiddenRow]
		public Dictionary<string, Developer> IdxDeveloperNames { get; set; } = new Dictionary<string, Developer>();

		/*public override string ToString()
		{
			return Name;
		}*/

		public void Load(List<ReleaseData> Items)
		{
			ReleaseDatas = Items;
			foreach (ReleaseData releaseData in Items)
			{
				ReleaseView releaseView = new ReleaseView(releaseData);
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
			Platform platform;
			if (!IdxPlatformNames.TryGetValue(releaseView.releaseData.Platform, out platform))
			{
				platform = new Platform()
				{
					Name = releaseView.releaseData.Platform,
				};
				IdxPlatformNames.Add(platform.Name, platform);
				Platforms.Add(platform);
			}
			platform.Releases.Add(releaseView);
			releaseView.Platform = platform;
			return platform;
		}

		private GameTitle AddTitle(ReleaseView releaseView)
		{
			GameTitle gameTitle;
			if (!IdxGameNames.TryGetValue(releaseView.Name, out gameTitle))
			{
				gameTitle = new GameTitle()
				{
					Name = releaseView.Name,
				};
				IdxGameNames.Add(gameTitle.Name, gameTitle);
				Games.Add(gameTitle);
			}
			gameTitle.Releases.Add(releaseView);
			releaseView.Title = gameTitle;
			return gameTitle;
		}

		private Publisher AddPublisher(ReleaseView releaseView)
		{
			Publisher publisher;
			if (!IdxPublisherNames.TryGetValue(releaseView.releaseData.Publisher, out publisher))
			{
				publisher = new Publisher()
				{
					Name = releaseView.releaseData.Publisher,
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
			Developer developer;
			if (!IdxDeveloperNames.TryGetValue(releaseView.releaseData.Developer, out developer))
			{
				developer = new Developer()
				{
					Name = releaseView.releaseData.Developer,
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
			Genre genre;
			if (!IdxGenreNames.TryGetValue(releaseView.releaseData.Genre, out genre))
			{
				genre = new Genre()
				{
					Name = releaseView.releaseData.Genre,
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
		public List<ReleaseView> Releases { get; set; } = new List<ReleaseView>();

		public override string ToString()
		{
			return Name;
		}
	}

	public class GameTitle
	{
		public string Name { get; set; }
		public List<ReleaseView> Releases { get; set; } = new List<ReleaseView>();

		public override string ToString()
		{
			return Name;
		}
	}

	public class Publisher
	{
		public string Name { get; set; }
		public HashSet<GameTitle> Titles { get; set; } = new HashSet<GameTitle>();
		public List<ReleaseView> Releases { get; set; } = new List<ReleaseView>();

		public override string ToString()
		{
			return Name;
		}
	}

	public class Developer
	{
		public string Name { get; set; }
		public HashSet<GameTitle> Titles { get; set; } = new HashSet<GameTitle>();
		public List<ReleaseView> Releases { get; set; } = new List<ReleaseView>();

		public override string ToString()
		{
			return Name;
		}
	}

	public class Genre
	{
		public string Name { get; set; }
		public HashSet<GameTitle> Titles { get; set; } = new HashSet<GameTitle>();
		public List<ReleaseView> Releases { get; set; } = new List<ReleaseView>();

		public override string ToString()
		{
			return Name;
		}
	}
}
