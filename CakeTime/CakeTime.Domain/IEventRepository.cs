namespace CakeTime.Domain;

public interface IEventRepository
{
    public Task<List<EventData>> GetEventsAsync();

    public Task AddEventAsync(EventData eventData);

    public Task UpdateEventAsync(EventData eventData);

    public Task DeleteEventAsync(EventData eventData);
}