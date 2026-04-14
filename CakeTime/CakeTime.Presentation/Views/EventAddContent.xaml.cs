using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class EventAddContent : EventContentBase
{
    public EventAddContent(EventAddViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}