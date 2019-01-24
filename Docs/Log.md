# Initial Setup Log

Add Atlas Submodule
- `git submodule add https://github.com/garyhertel/Atlas.git Imports/Atlas --recursive`

# Initialize the Atlas submodules
- `cd Imports/Atlas`
- `git submodule update --init Imports/AvaloniaUI/Avalonia.DataGrid`
- `git submodule update --init Imports/AvaloniaUI/AvaloniaEdit`
- `git submodule update --init Imports/AvaloniaUI/OxyPlot.Avalonia`

# Apply Avalonia Patches
- `git apply AvaloniaUI.diff`

# Restore nuget packages
- `dotnet restore`