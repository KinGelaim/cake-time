using CakeTime.Application;
using CakeTime.Domain;
using CakeTime.Infrastructure.Environment;

namespace CakeTime.Presentation.ViewModels;

public sealed class EventAddViewModel : NotificationObject
{
    private readonly EventService _eventService;

    public DelegateCommand AddEventCommand { get; }
    public DelegateCommand CloseEventCommand { get; }

    public event Action? OnCloseBtnClick;

    public EventData EventData
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged(nameof(EventData));
        }
    } = new EventData();

    public string? NameError
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged(nameof(NameError));
        }
    }

    public string? DayError
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged(nameof(DayError));
        }
    }

    public string? MonthError
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged(nameof(MonthError));
        }
    }

    public EventAddViewModel(EventService eventService)
    {
        _eventService = eventService;

        AddEventCommand = new DelegateCommand(OnAddEventBtnClick);
        CloseEventCommand = new DelegateCommand(OnCloseEventBtnClick);
    }

    private void OnAddEventBtnClick()
    {
        ValidateEventData();

        if (NameError is not null || DayError is not null || MonthError is not null)
        {
            return;
        }

        Task.Run(() => _eventService.AddEventAsync(EventData))
            .ContinueWith(t =>
            {
                if (!t.IsCompletedSuccessfully)
                {
                    return;
                }

                EventData = new EventData();
            });
    }

    private void OnCloseEventBtnClick()
    {
        EventData = new EventData();
        OnCloseBtnClick?.Invoke();
    }

    private void ValidateEventData()
    {
        NameError = string.IsNullOrEmpty(EventData.Name) || EventData.Name.Length < 3
            ? "Имя должно содержать минимум 3 символа"
            : null;
        DayError = EventData.Day is <= 0 or > 31
            ? "День должен быть между 1 и 31"
            : null;
        MonthError = EventData.Month is <= 0 or > 12
            ? "Месяц должен быть между 1 и 12"
            : null;
    }
}