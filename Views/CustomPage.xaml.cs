using NoPopsUI.Models;

namespace NoPopsUI.Views;

public partial class CustomPage : ContentPage
{
	public CustomPage()
	{
        InitializeComponent();
        CustomWebView.Navigating += OnCustomWebViewNavigating;
        SetBindingContext();
    }

    private void SetBindingContext() => BindingContext = new Custom();

    private void OnCustomWebViewNavigating(object? sender, WebNavigatingEventArgs e)
    {
        try
        {
            if (BindingContext is Custom custom)
            {
                if (!string.IsNullOrWhiteSpace(e.Url) && Uri.TryCreate(e.Url, UriKind.Absolute, out Uri? customSanitizedUrl))
                {
                    e.Cancel = !customSanitizedUrl.AbsoluteUri.StartsWith(custom.BaseUrl, StringComparison.CurrentCultureIgnoreCase);
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

    private void OnGoToButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is Custom custom)
        {
            if (!string.IsNullOrWhiteSpace(TargetUrlEntry.Text))
            {
                if (!TargetUrlEntry.Text.StartsWith(@$"{Uri.UriSchemeHttps}{Uri.SchemeDelimiter}"))
                {
                    TargetUrlEntry.Text = @$"{Uri.UriSchemeHttps}{Uri.SchemeDelimiter}{TargetUrlEntry.Text}";
                }
                if (Uri.TryCreate(TargetUrlEntry.Text, UriKind.Absolute, out Uri? sanitizedTargetUrl))
                {
                    custom.BaseUrl = @$"{Uri.UriSchemeHttps}{Uri.SchemeDelimiter}{sanitizedTargetUrl.Host}";
                    custom.TargetUrl = sanitizedTargetUrl.OriginalString;
                    custom.SanitizedUrl = sanitizedTargetUrl;

                    CustomWebView.Source = custom.SanitizedUrl;
                }
            }
        }
    }
}