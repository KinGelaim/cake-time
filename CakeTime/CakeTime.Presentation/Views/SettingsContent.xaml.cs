using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class SettingsContent : ContentView
{
	public SettingsContent()
	{
		InitializeComponent();
		BindingContext = new SettingsViewModel();
	}
}