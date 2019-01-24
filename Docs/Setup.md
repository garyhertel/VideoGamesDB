

# Setup
---
1. Clone VideoGamesDB
    - `git clone https://github.com/garyhertel/VideoGamesDB.git`
    - `cd VideoGamesDB`
    - Restore SubModules for AvaloniaUI (the nuget packages aren't recent enough)
    - `git submodule update --init --recursive`
    - Apply AvaloniaUI patches (mostly to update versions, need to add PRs for these)
      - `cd Imports/Atlas`
      - `git apply AvaloniaUI.diff`
2. Console
    - `dotnet build`
    - `dotnet run --project Programs/VideoGamesDB.Start.Avalonia/VideoGamesDB.Start.Avalonia.csproj`
3. IDE
  -Tested
    - Windows
      - Visual Studio 2017 - (recommended) (community edition or +)
    - Linux
        - Visual Studio Code
  - Open `VideoGamesDB.sln` in an IDE
  - Start VideoGamesDB in Debug Mode
    - At this stage, it's recommended to always run this program in debug mode to catch exceptions
4. Running
  - Configure Paths
    - After starting, Select `Settings` to change any of the default locations (not currently enabled)
    
