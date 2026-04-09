using CakeTime.Infrastructure.Environment;
using System.Collections.ObjectModel;

namespace CakeTime.Presentation.ViewModels;

public sealed class EventsListViewModel : NotificationObject
{
    private ObservableCollection<string> _events = [];
    public ObservableCollection<string> Events
    {
        get => _events;
        set
        {
            _events = value;
            OnPropertyChanged(nameof(Events));
        }
    }
}