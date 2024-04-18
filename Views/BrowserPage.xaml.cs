using Browser = NoPopsUI.Maui.ViewModels.Browser;

namespace NoPopsUI.Views;

public partial class BrowserPage : ContentPage
{
	public BrowserPage()
	{
		InitializeComponent();
        if (BindingContext is Browser browser && browser.CustomWebViewNavigating != null && browser.WebsitePickerSelectedIndexChanged != null)
        {
            CustomWebView.Navigating += browser.CustomWebViewNavigating;
            WebsitePicker.SelectedIndexChanged += browser.WebsitePickerSelectedIndexChanged;
            WebsitePicker.SetBinding(Picker.ItemsSourceProperty, nameof(browser.WebsitePickerItemsSource));
            WebsitePicker.SetBinding(Picker.SelectedItemProperty, nameof(browser.WebsitePickerSelectedItem));
            WebsitePicker.ItemDisplayBinding = new Binding(nameof(browser.WebsitePickerSelectedItem.Host));
        }
    }
}