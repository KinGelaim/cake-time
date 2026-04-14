using CakeTime.Application;

namespace CakeTime.Presentation.ViewModels;

public sealed class EventAddViewModel(EventService eventService) : EventViewModelBase(eventService)
{
    protected override void StartSaveData() =>
        Task.Run(() => _eventService.AddEventAsync(EventData))
            .ContinueWith(t =>
            {
                if (!t.IsCompletedSuccessfully)
                {
                    return;
                }

                ClearSelectedData();
            });
}