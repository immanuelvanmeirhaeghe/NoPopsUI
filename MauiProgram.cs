using NoPopsUI.Maui.Extensions;
using NoPopsUI.Views;

namespace NoPopsUI;

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
                fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FontAwesomeBrandsRegular");
                fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesomeFreeRegular");
                fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesomeFreeSolid");
            })
            .ConfigureApp()
            .ConfigureRouting(routes =>
            {
                routes.AddRoute("//main/home", typeof(HomePage));
                routes.AddRoute("//main/browser", typeof(BrowserPage));
                routes.AddRoute("//main/options", typeof(OptionsPage));
                routes.AddRoute("//main/about", typeof(AboutPage));
            });

        return builder.Build();
    }
}
