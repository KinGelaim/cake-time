using CakeTime.Application;
using CakeTime.Domain;

namespace CakeTime.Presentation.ViewModels;

public sealed class EventEditViewModel : EventViewModelBase
{
    public EventEditViewModel(int eventId, EventService eventService) : base(eventService)
    {
        EventData = _eventService.Events.First(e => e.Id == eventId);
        SelectedDay = EventData.Day;
        SelectedMonth = Months.First(m => m.Number == EventData.Month);
    }

    protected override void StartSaveData() =>
        Task.Run(() => _eventService.UpdateEventAsync(EventData))
            .ContinueWith(t =>
            {
                if (!t.IsCompletedSuccessfully)
                {
                    return;
                }

                ClearSelectedData();
            });
}