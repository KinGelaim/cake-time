using CakeTime.ViewModels;

namespace CakeTime.Views;

public partial class EventEditContent : ContentView
{
	public EventEditContent()
	{
		InitializeComponent();
		BindingContext = new EventEditViewModel();
	}
}