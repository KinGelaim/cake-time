namespace CakeTime.Presentation.Models;

public sealed record EventDataView(
    int Id,
    string Name,
    DateOnly Date);