using CakeTime.Infrastructure.Environment;
using System.Collections.ObjectModel;

namespace CakeTime.Presentation.ViewModels;

public sealed class EventsListViewModel : NotificationObject
{
    public ObservableCollection<string> Events
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged(nameof(Events));
        }
    } = [];
}