using NoPopsUI.Maui.Services;

namespace NoPopsUI
{
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
            ManageResources();
        }

        private static void ManageResources()
        {
            ResourceManager.MergedDictionaries = Shell.Current.Resources?.MergedDictionaries ?? [];
            if (ResourceManager.MergedDictionaries != null)
            {
                ResourceManager.MergeUserOptions();
            }
        }
    }
}
