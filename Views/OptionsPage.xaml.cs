using Browser = NoPopsUI.Maui.ViewModels.Browser;
namespace NoPopsUI.Views;

public partial class OptionsPage : ContentPage
{
	public OptionsPage()
	{
		InitializeComponent();
        if (BindingContext is Browser browser && browser.OnPickerSelectedIndexChanged != null)
        {
            WebsitePicker.SelectedIndexChanged += browser.OnPickerSelectedIndexChanged;
            WebsitePicker.SetBinding(Picker.ItemsSourceProperty, nameof(browser.Websites));
            WebsitePicker.SetBinding(Picker.SelectedItemProperty, nameof(browser.SelectedWebsite));
            WebsitePicker.ItemDisplayBinding = new Binding(nameof(browser.SelectedWebsite.Name));
        }
    }
}