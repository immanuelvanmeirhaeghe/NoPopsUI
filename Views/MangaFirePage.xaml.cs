using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class MangaFirePage : ContentPage
{
    public MangaFirePage()
	{
		InitializeComponent();
        WebViewMangaFire.Navigating += OnNavigatingWebViewMangaFire;        
        if (BindingContext is MangaFire && !string.IsNullOrWhiteSpace(MangaFire.BaseUrl))
        {
            WebViewMangaFire.Source = MangaFire.BaseUrl;
        }
    }   

    private void OnNavigatingWebViewMangaFire(object? sender, WebNavigatingEventArgs e)
    {
        try
        {
            if (BindingContext is MangaFire)
            {
                if (!string.IsNullOrWhiteSpace(e.Url) && Uri.TryCreate(e.Url, UriKind.RelativeOrAbsolute, out Uri? mangafireSanitizedUrl))
                {
                    MangaFire.SanitizedUrl = mangafireSanitizedUrl;

                    e.Cancel = !MangaFire.SanitizedUrl.AbsoluteUri.StartsWith(MangaFire.BaseUrl, StringComparison.CurrentCultureIgnoreCase);
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