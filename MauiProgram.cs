using Microsoft.Extensions.Configuration;
using NoPopsUI.Views;

namespace NoPopsUI
{
    public static class MauiProgram
    {
        private const string AppsettingsFilePath = "appsettings.json";

        public static IDictionary<string, object> RegisteredRoutes { get; private set; } = new Dictionary<string, object>();

        public static IConfigurationManager? Configuration {  get; private set; }

        public static MauiAppBuilder ConfigureApp(this MauiAppBuilder builder)
        {
            var jsonFS = Stream.Null;
            using var readContentTask = Task.Run(async () =>
                    jsonFS = await FileSystem.OpenAppPackageFileAsync(AppsettingsFilePath)
            );
            var config = readContentTask.Result;
            if (config != null)
            {
                builder.Configuration
                   .AddJsonStream(jsonFS)
                    .Build();
            }

            Configuration = builder.Configuration;
            return builder;
        }
        
        public static MauiAppBuilder ConfigureRoutes(this MauiAppBuilder builder)
        {
            RegisteredRoutes = new Dictionary<string, object>
            {
                { "//main/home", typeof(HomePage) },
                { "//main/browser", typeof(BrowserPage) },
                { "//main/about", typeof(AboutPage) },
                { "//main/options", typeof(OptionsPage) },
            };
            Maui.Controls.Routing.RegisteredPages = new Dictionary<string, string>
            {
                { nameof(HomePage), "//main/home" },
                { nameof(BrowserPage), "//main/browser" },
                { nameof(AboutPage), "//main/about" },
                { nameof(OptionsPage),"//main/options" },
            };

            if (RegisteredRoutes != null)
            {
                foreach (var route in RegisteredRoutes)
                {
                    Routing.RegisterRoute(route.Key, (Type)route.Value);
                }
            }
            return builder;
        }

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
                });
            builder.ConfigureApp();
            builder.ConfigureRoutes();
            return builder.Build();
        }
    }
}
