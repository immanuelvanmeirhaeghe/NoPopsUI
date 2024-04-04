using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class AniwavePage : ContentPage
{
    public AniwavePage()
	{
		InitializeComponent();
        WebViewAniwave.Navigating += OnNavigatingWebViewAniwave;
        if (BindingContext is Aniwave && !string.IsNullOrWhiteSpace(Aniwave.BaseUrl))
        {
            WebViewAniwave.Source = Aniwave.BaseUrl;
        }
    }

    private void OnNavigatingWebViewAniwave(object? sender, WebNavigatingEventArgs e)
    {
        try
        {
            if (BindingContext is Aniwave)
            {
                if (!string.IsNullOrWhiteSpace(e.Url) && Uri.TryCreate(e.Url, UriKind.RelativeOrAbsolute, out Uri? aniwaveSanitizedUrl))
                {
                    Aniwave.SanitizedUrl = aniwaveSanitizedUrl;

                    e.Cancel = !Aniwave.SanitizedUrl.AbsoluteUri.StartsWith(Aniwave.BaseUrl, StringComparison.CurrentCultureIgnoreCase);
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