using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class MangaFirePage : ContentPage
{
    public MangaFirePage()
	{
		InitializeComponent();
        WebViewMangaFire.Navigating += WebViewMangaFireOnNavigating;
        if (BindingContext is MangaFire)
        {
            WebViewMangaFire.Source = MangaFire.BaseUrl;
        }
    }

    private void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        if (BindingContext is MangaFire)
        {
            if (IsSet(Shell.TabBarIsVisibleProperty))
            {
                Shell.SetTabBarIsVisible(this, true);
            }
            if (IsSet(Shell.NavBarIsVisibleProperty))
            {
                Shell.SetNavBarIsVisible(this, true);
            }
        }
    }

    private void WebViewMangaFireOnNavigating(object? sender, WebNavigatingEventArgs e)
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