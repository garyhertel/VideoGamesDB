# Setup
---
1. Clone VideoGamesDB
    - `git clone https://github.com/garyhertel/VideoGamesDB.git`
    - `cd VideoGamesDB`
    - Restore SubModules for Atlas Import
    - `git submodule update --init --recursive`
2. Console
    - `dotnet build`
    - `dotnet run --project Programs/VideoGamesDB.Start.Avalonia/VideoGamesDB.Start.Avalonia.csproj`
3. IDEs
  - Visual Studio (Windows Only)
  - JetBrains Rider
  - Visual Studio Code
- Open `VideoGamesDB.sln` in an IDE
- Start VideoGamesDB in Debug Mode
  - At this stage, it's recommended to always run this program in debug mode to catch exceptions
    
