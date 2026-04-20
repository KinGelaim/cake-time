using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class SettingsContent : ContentView
{
    public SettingsContent(SettingsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}