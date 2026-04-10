using CakeTime.Application;
using CakeTime.Domain;
using CakeTime.Infrastructure.Environment;
using System.Collections.ObjectModel;

namespace CakeTime.Presentation.ViewModels;

public sealed class EventsListViewModel : NotificationObject
{
    private readonly EventService _eventService;

    public ObservableCollection<EventData> Events
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged(nameof(Events));
        }
    } = [];

    public DelegateCommand<int> DeleteEventCommand { get; }

    public EventsListViewModel(EventService eventService)
    {
        _eventService = eventService;

        DeleteEventCommand = new DelegateCommand<int>(OnDeleteEventBtnClick);

        _eventService.EventsChanged += LoadEvents;
        LoadEvents();
    }

    private void LoadEvents()
    {
        Events.Clear();
        foreach (var eventData in _eventService.Events)
        {
            Events.Add(eventData);
        }
    }

    private void OnDeleteEventBtnClick(int id) =>
        Task.Run(() => _eventService.DeleteEventAsync(id));
}