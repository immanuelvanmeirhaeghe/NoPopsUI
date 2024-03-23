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
            WebViewMangaFire.Source = MangaFire.MangaFireBaseUrl;
        }
    }

    private void WebViewMangaFire_Navigating(object? sender, WebNavigatingEventArgs e)
    {
        try
        {
            if (BindingContext is MangaFire)
            {
                if (!string.IsNullOrWhiteSpace(e.Url) && Uri.TryCreate(e.Url, UriKind.Absolute, out Uri? mangaFireSanitizedUrl))
                {
                    MangaFire.SanitizedUrl = mangaFireSanitizedUrl;

                    if (MangaFire.FacebookDomain.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        || MangaFire.XDomain.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        || MangaFire.MessengerDomain.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        || MangaFire.RedditDomain.Equals(MangaFire.SanitizedUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                        || MangaFire.SanitizedUrl.AbsoluteUri.StartsWith(MangaFire.MangaFireBaseUrl)
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