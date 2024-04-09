using NoPopsUI.Maui.ViewModels;

namespace NoPopsUI.Views;

public partial class CustomBrowserPage : ContentPage
{
	public CustomBrowserPage()
	{
		InitializeComponent();
        if (BindingContext is CustomBrowser customBrowser && customBrowser.OnNavigatingWebView != null && customBrowser.OnPickerSelectedIndexChanged != null)
        {
            CustomWebView.Navigating += customBrowser.OnNavigatingWebView;            
            WebsitePicker.SelectedIndexChanged += customBrowser.OnPickerSelectedIndexChanged;
            WebsitePicker.SetBinding(Picker.ItemsSourceProperty, nameof(customBrowser.Websites));
            WebsitePicker.SetBinding(Picker.SelectedItemProperty, nameof(customBrowser.SelectedWebsite));
            WebsitePicker.ItemDisplayBinding = new Binding(nameof(customBrowser.SelectedWebsite.Name));
        }
    }
}