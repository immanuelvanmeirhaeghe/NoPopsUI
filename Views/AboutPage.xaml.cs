using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
	{
		InitializeComponent();
        InitAbout();
	}

    private void InitAbout()
    {
        About about = new()
        {
            Title = AppInfo.Name,
            Version = AppInfo.VersionString
        };
        BindingContext = about;
    }

    private async void GoToGitHubProject_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is About about)
        {
            await Launcher.Default.OpenAsync(about.GitHubProjectUrl);
        }
    }
}