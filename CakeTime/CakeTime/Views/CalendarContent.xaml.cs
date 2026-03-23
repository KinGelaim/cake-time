using CakeTime.ViewModels;

namespace CakeTime.Views;

public partial class CalendarContent : ContentView
{
	public CalendarContent()
	{
		InitializeComponent();
		BindingContext = new CalendarViewModel();
    }
}