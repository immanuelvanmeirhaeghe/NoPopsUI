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
        }
    }
}
