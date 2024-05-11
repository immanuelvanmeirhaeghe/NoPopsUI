using NoPopsUI.Maui.Services;

namespace NoPopsUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        RequestedThemeChanged += (s, a) =>
        {
            AppTheme currentTheme = a.RequestedTheme;
            UserAppTheme = currentTheme;
        };
        MainPage = new AppShell();
        LoadResources();
        LoadPreferences();
    }

    public static void LoadResources()
    {
        ResourceManager.MergedDictionaries = Current?.Resources?.MergedDictionaries ?? [];
        if (ResourceManager.MergedDictionaries != null && ResourceManager.MergeUserOptions())
        {
            return;
        }
    }

    public static void LoadPreferences()
    {
        if (PreferenceManager.LoadUserPreferences())
        {
            return;
        }
    }
}
