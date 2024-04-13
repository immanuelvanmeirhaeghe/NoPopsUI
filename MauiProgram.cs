using Microsoft.Extensions.Configuration;
using NoPopsUI.Views;
using System.Reflection;

namespace NoPopsUI
{
    public static class MauiProgram
    {
        private const string AppsettingsFilePath = "appsettings.json";

        public static IConfigurationManager? Configuration {  get; private set; }

        public static MauiAppBuilder ConfigureApp(this MauiAppBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string? name = assembly.GetName().Name;
            string appsettingsJsonEmbeddedResourceKey = $"{name}.{AppsettingsFilePath}";
            
            if (appsettingsJsonEmbeddedResourceKey != null)
            {
                using var jsonFS = assembly.GetManifestResourceStream(appsettingsJsonEmbeddedResourceKey);
                if (jsonFS != null)
                {
                    builder.Configuration
                       .AddJsonStream(jsonFS)
                        .Build();
                }              
            }
            Configuration = builder.Configuration;
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
            //.ConfigureApp();
            Routing.RegisterRoute("//main/options", typeof(OptionsPage));

            return builder.Build();
        }
    }
}
