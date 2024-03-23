using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class MangaFirePage : ContentPage
{
    public MangaFirePage()
	{
		InitializeComponent();

        WebViewMangaFire.Source = UrlWhiteList.MangaFireBase;
        WebViewMangaFire.Navigating += WebViewMangaFire_Navigating;

    }

    private void WebViewMangaFire_Navigating(object? sender, WebNavigatingEventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(e.Url) && Uri.TryCreate(e.Url, UriKind.Absolute, out Uri? sanUrl))
            {
                if (UrlWhiteList.FacebookDomain.Equals(sanUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                    || UrlWhiteList.XDomain.Equals(sanUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                    || UrlWhiteList.MessengerDomain.Equals(sanUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                    || UrlWhiteList.RedditDomain.Equals(sanUrl.AbsolutePath, StringComparison.CurrentCultureIgnoreCase)
                    || sanUrl.AbsoluteUri.StartsWith(UrlWhiteList.MangaFireBase)
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
        catch (Exception)
        {
            e.Cancel = true;
        }
    }
}