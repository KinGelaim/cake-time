using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class EventListContent : ContentView
{
    public EventListContent(EventsListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}