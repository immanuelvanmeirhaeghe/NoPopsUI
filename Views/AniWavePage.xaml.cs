using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class AniWavePage : ContentPage
{
    public AniWavePage()
	{
		InitializeComponent();
        WebViewAniWave.Navigating += WebViewAniWave_Navigating;
        if (BindingContext is AniWave)
        {
            WebViewAniWave.Source = AniWave.AniWaveBaseUrl;
        }
    }

    private void WebViewAniWave_Navigating(object? sender, WebNavigatingEventArgs e)
    {
        try
        {
            if (BindingContext is AniWave)
            {
                if (!string.IsNullOrWhiteSpace(e.Url) && Uri.TryCreate(e.Url, UriKind.Absolute, out Uri? aniWaveSanitizedUrl))
                {
                    AniWave.SanitizedUrl = aniWaveSanitizedUrl;

                    if (AniWave.DiscordDomain.Equals(AniWave.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        || AniWave.XDomain.Equals(AniWave.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        || AniWave.RedditDomain.Equals(AniWave.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        || AniWave.SanitizedUrl.AbsoluteUri.StartsWith(AniWave.AniWaveBaseUrl)
                        )
                    {
                        e.Cancel = false;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        catch (Exception)
        {
            e.Cancel = true;
        }
    }
}