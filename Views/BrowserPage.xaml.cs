using CustomBrowser = NoPopsUI.Maui.ViewModels.Browser;
using CustomControls = NoPopsUI.Maui.Controls;
using Microsoft.Maui.ApplicationModel;

namespace NoPopsUI.Views;

public partial class BrowserPage : ContentPage
{
    public BrowserPage()
    {
        InitializeComponent();
        if (BindingContext is CustomBrowser browser)
        {
            CustomWebView.Navigating += browser.CustomWebViewNavigating;
            ShellTitleViewPinchGestureRecognizer.PinchUpdated += browser.ShellTitleViewOnPinchedUpdated;
            
            WebsitePicker.SelectedIndexChanged += browser.WebsitePickerSelectedIndexChanged;
            WebsitePicker.SetBinding(Picker.ItemsSourceProperty, nameof(browser.WebsitePickerItemsSource));
            WebsitePicker.SetBinding(Picker.SelectedItemProperty, nameof(browser.WebsitePickerSelectedItem));
            WebsitePicker.ItemDisplayBinding = new Binding(nameof(browser.WebsitePickerSelectedItem.Host));
           
        }
    }
}