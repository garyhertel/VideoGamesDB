using Avalonia;
using Avalonia.Markup.Xaml;

namespace VideoGamesDB.Start.Avalonia
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
	}
}
