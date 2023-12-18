using MAUIView.ViewModel;
using Microsoft.Extensions.Logging;

namespace MAUIView;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .Services
            .AddSingleton<MainPage>()
            .AddSingleton<Board>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
