using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class EventAddContent : ContentView
{
    public EventAddContent(EventAddViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}