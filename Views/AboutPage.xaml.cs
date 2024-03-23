using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
	{
		InitializeComponent();
	}

    private async void GoToGitHubProject_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is About)
        {
            await Launcher.Default.OpenAsync(About.GitHubProjectUrl);
        }
    }
}