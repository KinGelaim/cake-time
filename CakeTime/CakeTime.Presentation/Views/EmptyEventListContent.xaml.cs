using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class EmptyEventListContent : ContentView
{
    public EmptyEventListContent()
    {
        InitializeComponent();
        BindingContext = new EmptyEventListViewModel();
    }
}