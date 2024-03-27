using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
	{
		InitializeComponent();
       
        SetBindingContext();
	}

    private void SetBindingContext() => BindingContext = new About {
        Title = AppInfo.Name,
        Version = AppInfo.VersionString
    };

    private async void OnGoToGitHubProjectButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is About about)
        {
            bool launcherOpened = await Launcher.Default.TryOpenAsync(about.GitHubScheme);
            if (!launcherOpened) 
                await Launcher.Default.OpenAsync(about.GitHubProjectUrl);
        }
    }
}