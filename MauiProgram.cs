using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace NoPopsUI
{
    public static class MauiProgram
    {
        private const string AppsettingsFilePath = "appsettings.json";

        private static IConfigurationManager? _config;
        public static IConfigurationManager Configuration
        {
            get => _config;
            private set
            {
                if (value != null)
                {
                    _config = value;
                }
            }
        }

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
                else
                {
                    using var fileStream = assembly.GetFile(AppContext.BaseDirectory+AppsettingsFilePath);
                    if (fileStream != null)
                    {
                        builder.Configuration
                           .AddJsonStream(fileStream)
                            .Build();
                    }
                    else 
                    {
                        builder.Configuration
                           .AddJsonFile(AppsettingsFilePath, optional: true, reloadOnChange: true)
                            .Build();
                    }
                }
            }

            builder.Configuration.AddConfiguration(Configuration);
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

            return builder.Build();
        }
    }
}
