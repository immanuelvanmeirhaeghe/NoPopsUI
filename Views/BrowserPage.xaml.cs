using Browser = NoPopsUI.Maui.ViewModels.Browser;

namespace NoPopsUI.Views;

public partial class BrowserPage : ContentPage
{
	public BrowserPage()
	{
		InitializeComponent();
        if (BindingContext is Browser browser && browser.OnNavigatingWebView != null && browser.OnPickerSelectedIndexChanged != null)
        {
            CustomWebView.Navigating += browser.OnNavigatingWebView;
            WebsitePicker.SelectedIndexChanged += browser.OnPickerSelectedIndexChanged;
            WebsitePicker.SetBinding(Picker.ItemsSourceProperty, nameof(browser.Websites));
            WebsitePicker.SetBinding(Picker.SelectedItemProperty, nameof(browser.SelectedWebsite));
            WebsitePicker.ItemDisplayBinding = new Binding(nameof(browser.SelectedWebsite.Name));
        }
    }
}