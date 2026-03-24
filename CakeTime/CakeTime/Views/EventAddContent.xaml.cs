using CakeTime.ViewModels;

namespace CakeTime.Views;

public partial class EventAddContent : ContentView
{
	public EventAddContent()
	{
		InitializeComponent();
		BindingContext = new EventAddViewModel();
	}
}