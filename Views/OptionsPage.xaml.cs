using Options = NoPopsUI.Maui.ViewModels.Options;
namespace NoPopsUI.Views;

public partial class OptionsPage : ContentPage
{
    public OptionsPage()
	{
		InitializeComponent();
		if (BindingContext is Options options)
		{
            WebsitePicker.SelectedIndexChanged += options.OnPickerSelectedIndexChanged;
            WebsitePicker.SetBinding(Picker.ItemsSourceProperty, nameof(options.Websites));
            WebsitePicker.SetBinding(Picker.SelectedItemProperty, nameof(options.SelectedWebsite));
            WebsitePicker.ItemDisplayBinding = new Binding(nameof(options.SelectedWebsite.Name));
        }
    }
}