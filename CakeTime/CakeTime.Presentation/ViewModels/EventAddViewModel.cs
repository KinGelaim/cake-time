using CakeTime.Application;
using CakeTime.Domain;
using CakeTime.Infrastructure.Environment;
using CakeTime.Presentation.Models;
using System.Collections.ObjectModel;

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

#pragma warning disable CA1822 // Пометьте члены как статические
    public ObservableCollection<MonthItem> Months =>
    [
        new MonthItem { Number = 1, Name = "Январь" },
        new MonthItem { Number = 2, Name = "Февраль" },
        new MonthItem { Number = 3, Name = "Март" },
        new MonthItem { Number = 4, Name = "Апрель" },
        new MonthItem { Number = 5, Name = "Май" },
        new MonthItem { Number = 6, Name = "Июнь" },
        new MonthItem { Number = 7, Name = "Июль" },
        new MonthItem { Number = 8, Name = "Август" },
        new MonthItem { Number = 9, Name = "Сентябрь" },
        new MonthItem { Number = 10, Name = "Октябрь" },
        new MonthItem { Number = 11, Name = "Ноябрь" },
        new MonthItem { Number = 12, Name = "Декабрь" }
    ];
#pragma warning restore CA1822 // Пометьте члены как статические

    public MonthItem? SelectedMonth { get; set; }
    public int? SelectedDay { get; set; }

    public EventAddViewModel(EventService eventService)
    {
        _eventService = eventService;

        AddEventCommand = new DelegateCommand(OnAddEventBtnClick);
        CloseEventCommand = new DelegateCommand(OnCloseEventBtnClick);
    }

    private void OnAddEventBtnClick()
    {
        EventData.Day = SelectedDay ?? 0;
        EventData.Month = SelectedMonth?.Number ?? 0;

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

                ClearSelectedData();
            });
    }

    private void OnCloseEventBtnClick()
    {
        ClearSelectedData();
        OnCloseBtnClick?.Invoke();
    }

    private void ClearSelectedData()
    {
        SelectedDay = null;
        SelectedMonth = null;
        EventData = new EventData();
    }

    private void ValidateEventData()
    {
        NameError = string.IsNullOrEmpty(EventData.Name) || EventData.Name.Length < 3
            ? "Имя должно содержать минимум 3 символа"
            : null;
        DayError = SelectedDay is null
            ? "Необходимо заполнить день"
            : EventData.Day is <= 0 or > 31
                ? "День должен быть между 1 и 31"
                : null;
        MonthError = SelectedMonth is null
            ? "Необходимо выбрать месяц"
            : EventData.Month is <= 0 or > 12
                ? "Месяц должен быть между 1 и 12"
                : null;
    }
}