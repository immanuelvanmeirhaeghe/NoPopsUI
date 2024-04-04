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
        AppTitle = AppInfo.Name,
        AppVersion = AppInfo.VersionString
    };

    private async void OnButtonClickedGoToGitHub(object sender, EventArgs e)
    {
        if (BindingContext is About about
            && !string.IsNullOrWhiteSpace(about.GitHubScheme)
            && !await Launcher.Default.TryOpenAsync(about.GitHubScheme))
        {
            await Launcher.Default.OpenAsync(about.GitHubProjectUrl);
        }
    }
}