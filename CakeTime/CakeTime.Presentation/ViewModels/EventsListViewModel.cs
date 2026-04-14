using CakeTime.Application;
using CakeTime.Infrastructure.Environment;
using CakeTime.Presentation.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace CakeTime.Presentation.ViewModels;

public sealed class EventsListViewModel : NotificationObject
{
    private readonly EventService _eventService;

    public ObservableCollection<EventDataGroup> EventsGroups
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged(nameof(EventsGroups));
        }
    } = [];

    public DelegateCommand<int> DeleteEventCommand { get; }

    public EventsListViewModel(EventService eventService)
    {
        _eventService = eventService;

        DeleteEventCommand = new DelegateCommand<int>(OnDeleteEventBtnClick);

        _eventService.EventsChanged += LoadEvents;

        Task.Run(() => _eventService.LoadEventsAsync())
            .ContinueWith(t =>
            {
                if (!t.IsCompletedSuccessfully)
                {
                    return;
                }

                LoadEvents();
            });
    }

    private void LoadEvents()
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var currentYear = today.Year;
        var nextYear = currentYear + 1;

        // Преобразуем события в даты с учетом следующего года, если нужно
        var eventsWithDate = _eventService.Events
            .Select(e =>
            {
                var eventDateThisYear = new DateOnly(currentYear, e.Month, e.Day);
                var eventDateNextYear = new DateOnly(nextYear, e.Month, e.Day);

                // Если дата в текущем году еще не прошла, использовать ее, иначе следующий год
                var targetDate = eventDateThisYear >= today
                    ? eventDateThisYear
                    : eventDateNextYear;
                return new { Event = e, Date = targetDate };
            })
            .ToList();

        // Сортируем по дате
        var sortedEvents = eventsWithDate.OrderBy(e => e.Date).ToList();

        // Группируем по месяцам и годам
        var grouped = sortedEvents
            .GroupBy(e => new
            {
                e.Date.Year,
                MonthName = e.Date.ToString("MMMM", new CultureInfo("ru-RU"))
            })
            .Select(g =>
                new EventDataGroup($"{g.Key.MonthName} {g.Key.Year}")
                {
                    Events = g
                        .Select(e => new EventDataView(e.Event.Id, e.Event.Name, e.Date))
                        .ToList()
                })
            .ToList();

        EventsGroups.Clear();
        foreach (var group in grouped)
        {
            EventsGroups.Add(group);
        }
    }

    private void OnDeleteEventBtnClick(int id) =>
        Task.Run(() => _eventService.DeleteEventAsync(id));
}