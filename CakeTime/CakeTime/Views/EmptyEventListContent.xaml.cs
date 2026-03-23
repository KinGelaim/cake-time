using CakeTime.ViewModels;

namespace CakeTime.Views;

public partial class EmptyEventListContent : ContentView
{
	public EmptyEventListContent()
	{
		InitializeComponent();
		BindingContext = new EmptyEventListViewModel();
    }
}