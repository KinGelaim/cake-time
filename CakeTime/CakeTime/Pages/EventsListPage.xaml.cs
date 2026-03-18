using CakeTime.ViewModels;

namespace CakeTime.Pages;

public partial class EventsListPage : ContentPage
{
	public EventsListPage(EventsListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}