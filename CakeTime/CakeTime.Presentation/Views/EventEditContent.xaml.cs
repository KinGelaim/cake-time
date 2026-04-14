using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class EventEditContent : ContentView
{
    public EventEditContent(EventEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}