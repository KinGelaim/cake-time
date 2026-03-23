using CakeTime.ViewModels;

namespace CakeTime.Views;

public partial class EventListContent : ContentView
{
	public EventListContent()
	{
		InitializeComponent();
        BindingContext = new EventsListViewModel();
    }
}