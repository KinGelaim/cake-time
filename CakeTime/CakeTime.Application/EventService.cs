using CakeTime.Domain;

namespace CakeTime.Application;

public sealed class EventService(IEventRepository eventRepository)
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public List<EventData> Events { get; private set; } = [];

    public event Action? EventsChanged;

    public async Task<List<EventData>> LoadEventsAsync() =>
        Events = await GetEventsAsync();

    private async Task<List<EventData>> GetEventsAsync() =>
        await _eventRepository.GetEventsAsync();

    public async Task AddEventAsync(EventData eventData)
    {
        await _eventRepository.AddEventAsync(eventData);
        await LoadEventsAsync();
        EventsChanged?.Invoke();
    }

    public async Task UpdateEventAsync(EventData eventData)
    {
        await _eventRepository.UpdateEventAsync(eventData);
        await LoadEventsAsync();
        EventsChanged?.Invoke();
    }

    public async Task DeleteEventAsync(int id)
    {
        var eventData = Events.FirstOrDefault(x => x.Id == id);
        if (eventData is not null)
        {
            await _eventRepository.DeleteEventAsync(eventData);
            await LoadEventsAsync();
            EventsChanged?.Invoke();
        }
    }
}