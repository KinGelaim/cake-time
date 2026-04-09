using CakeTime.Presentation.ViewModels;

namespace CakeTime.Presentation.Views;

public partial class CalendarContent : ContentView
{
	public CalendarContent()
	{
		InitializeComponent();
		BindingContext = new CalendarViewModel();
    }
}