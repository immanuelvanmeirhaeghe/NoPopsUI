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
                if (!string.IsNullOrWhiteSpace(e.Url) && Uri.TryCreate(e.Url, UriKind.RelativeOrAbsolute, out Uri? mangafireSanitizedUrl))
                {
                    MangaFire.SanitizedUrl = mangafireSanitizedUrl;

                    e.Cancel = !MangaFire.SanitizedUrl.AbsoluteUri.StartsWith(MangaFire.BaseUrl);
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