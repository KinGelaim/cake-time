using CakeTime.ViewModels;

namespace CakeTime.Views;

public partial class SettingsContent : ContentView
{
	public SettingsContent()
	{
		InitializeComponent();
		BindingContext = new SettingsViewModel();
	}
}