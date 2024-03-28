using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class AniwavePage : ContentPage
{
    public AniwavePage()
	{
		InitializeComponent();
        WebViewAniwave.Navigating += OnNavigatingWebViewAniwave;
        if (BindingContext is Aniwave)
        {
            WebViewAniwave.Source = Aniwave.BaseUrl;
        }
    }

    private void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        if (BindingContext is Aniwave)
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

    private void OnNavigatingWebViewAniwave(object? sender, WebNavigatingEventArgs e)
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