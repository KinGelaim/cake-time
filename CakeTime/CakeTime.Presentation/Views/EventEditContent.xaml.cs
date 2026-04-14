using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class EventEditContent : EventContentBase
{
    public EventEditContent(EventEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}