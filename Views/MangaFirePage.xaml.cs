using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class MangaFirePage : ContentPage
{
    public MangaFirePage()
	{
		InitializeComponent();
        WebViewMangaFire.Navigating += WebViewMangaFire_Navigating;
        if (BindingContext is MangaFire)
        {
            WebViewMangaFire.Source = MangaFire.BaseUrl;
        }
    }

    private void WebViewMangaFire_Navigating(object? sender, WebNavigatingEventArgs e)
    {
        try
        {
            if (BindingContext is MangaFire)
            {
                if (!string.IsNullOrWhiteSpace(e.Url) && Uri.TryCreate(e.Url, UriKind.Absolute, out Uri? mangafireSanitizedUrl))
                {
                    MangaFire.SanitizedUrl = mangafireSanitizedUrl;

                    e.Cancel = !MangaFire.ShareOnFacebookUrl.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        && !MangaFire.ShareOnTwitterUrl.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        && !MangaFire.ShareOnFacebookMessengerUrl.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        && !MangaFire.ShareOnRedditUrl.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        && !MangaFire.JoinUsOnRedditUrl.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        && !MangaFire.DiscordInviteUrl.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        && !MangaFire.SanitizedUrl.AbsoluteUri.StartsWith(MangaFire.BaseUrl)
                        && !MangaFire.SanitizedUrl.AbsoluteUri.StartsWith(MangaFire.DisqusBaseUrl);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        catch (Exception)
        {
            e.Cancel = true;
        }
    }
}