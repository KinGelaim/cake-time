namespace CakeTime.Presentation.Models;

public sealed class EventDataGroup(string title)
{
    public string Title { get; set; } = title;
    public List<EventDataView> Events { get; set; } = [];
}