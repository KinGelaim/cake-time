using CakeTime.Domain;

namespace CakeTime.Infrastructure;

public sealed class EventRepository : IEventRepository
{
    private readonly LocalDBService _localDBService;

    public EventRepository() => _localDBService = new LocalDBService();

    public async Task<List<EventData>> GetEventsAsync() =>
        await _localDBService.Connection.Table<EventData>().ToListAsync();

    public async Task AddEventAsync(EventData eventData) =>
        await _localDBService.Connection.InsertAsync(eventData);

    public async Task UpdateEventAsync(EventData eventData) =>
        await _localDBService.Connection.UpdateAsync(eventData);

    public async Task DeleteEventAsync(EventData eventData) =>
        await _localDBService.Connection.DeleteAsync(eventData);
}