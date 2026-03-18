using CakeTime.Environment;
using System.Collections.ObjectModel;

namespace CakeTime.ViewModels;

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
            OnPropertyChanged(nameof(IsEventsEmpty));
            OnPropertyChanged(nameof(HasAnyEvents));
        }
    }

    public bool IsEventsEmpty => Events.Count == 0;
    public bool HasAnyEvents => Events.Count != 0;
}