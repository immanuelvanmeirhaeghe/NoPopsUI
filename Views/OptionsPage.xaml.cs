using Options = NoPopsUI.Maui.ViewModels.Options;
namespace NoPopsUI.Views;

public partial class OptionsPage : ContentPage
{
    public OptionsPage()
	{
		InitializeComponent();
		if (BindingContext is Options options)
		{
            WebsitePicker.SelectedIndexChanged += options.WebsitePickerSelectedIndexChanged;
            WebsitePicker.SetBinding(Picker.ItemsSourceProperty, nameof(options.WebsitePickerItemsSource));
            WebsitePicker.SetBinding(Picker.SelectedItemProperty, nameof(options.WebsitePickerSelectedItem));
            WebsitePicker.ItemDisplayBinding = new Binding(nameof(options.WebsitePickerSelectedItem.Host));
        }
    }
}