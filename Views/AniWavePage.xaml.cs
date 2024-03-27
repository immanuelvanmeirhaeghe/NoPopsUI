using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class AniwavePage : ContentPage
{
    public AniwavePage()
	{
		InitializeComponent();
        WebViewAniwave.Navigating += WebViewAniWave_Navigating;
        if (BindingContext is Aniwave)
        {
            WebViewAniwave.Source = Aniwave.BaseUrl;
        }
    }

    private void WebViewAniWave_Navigating(object? sender, WebNavigatingEventArgs e)
    {
        try
        {
            if (BindingContext is Aniwave)
            {
                if (!string.IsNullOrWhiteSpace(e.Url) && Uri.TryCreate(e.Url, UriKind.Absolute, out Uri? aniwaveSanitizedUrl))
                {
                    Aniwave.SanitizedUrl = aniwaveSanitizedUrl;

                    e.Cancel = !Aniwave.SanitizedUrl.AbsoluteUri.StartsWith(Aniwave.BaseUrl, StringComparison.CurrentCultureIgnoreCase)
                        && !Aniwave.SanitizedUrl.AbsoluteUri.StartsWith(Aniwave.FriendsMoviesBaseUrl, StringComparison.CurrentCultureIgnoreCase)
                        && !Aniwave.SanitizedUrl.AbsoluteUri.StartsWith(Aniwave.FriendsLiveBaseUrl, StringComparison.CurrentCultureIgnoreCase)
                        && !Aniwave.SanitizedUrl.AbsoluteUri.StartsWith(Aniwave.MangaFireBaseUrl, StringComparison.CurrentCultureIgnoreCase)
                        && !Aniwave.SanitizedUrl.AbsoluteUri.StartsWith(Aniwave.DisqusBaseUrl, StringComparison.CurrentCultureIgnoreCase);
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