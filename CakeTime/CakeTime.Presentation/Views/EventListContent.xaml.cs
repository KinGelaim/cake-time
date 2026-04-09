using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class EventListContent : ContentView
{
    public EventListContent()
    {
        InitializeComponent();
        BindingContext = new EventsListViewModel();
    }
}