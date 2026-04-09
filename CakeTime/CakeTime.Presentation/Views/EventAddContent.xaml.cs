using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class EventAddContent : ContentView
{
    public EventAddContent()
    {
        InitializeComponent();
        BindingContext = new EventAddViewModel();
    }
}