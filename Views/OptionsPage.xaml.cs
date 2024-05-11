using CustomOptions = NoPopsUI.Maui.ViewModels.Options;
using CustomControls = NoPopsUI.Maui.Controls;
namespace NoPopsUI.Views;

public partial class OptionsPage : ContentPage
{
    public OptionsPage()
    {
        InitializeComponent();
        if (BindingContext is CustomOptions options)
        {
            AddWebsiteEntry.TextChanged += options.AddWebsiteEntryTextChanged;
            AddWebsiteEntry.SetBinding(Entry.TextProperty, nameof(options.AddWebsiteEntryText));
            
            WebsitePicker.SelectedIndexChanged += options.WebsitePickerSelectedIndexChanged;
            WebsitePicker.SetBinding(Picker.ItemsSourceProperty, nameof(options.WebsitePickerItemsSource));
            WebsitePicker.SetBinding(Picker.SelectedItemProperty, nameof(options.WebsitePickerSelectedItem));
            WebsitePicker.ItemDisplayBinding = new Binding(nameof(options.WebsitePickerSelectedItem.Host));
           
            UseDefaultBrowserCheckBox.CheckedChanged += options.CustomCheckBoxCheckedChanged;
            CustomControls.UseDefaultBrowserCheckBox.Control = UseDefaultBrowserCheckBox;
                        
            AllowTransformsCheckBox.CheckedChanged += options.CustomCheckBoxCheckedChanged;
            CustomControls.AllowTransformsCheckBox.Control = AllowTransformsCheckBox;
        }
    }
}