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

    public EventAddViewModel(EventService eventService)
    {
        _eventService = eventService;

        AddEventCommand = new DelegateCommand(OnAddEventBtnClick);
        CloseEventCommand = new DelegateCommand(OnCloseEventBtnClick);
    }

    private void OnAddEventBtnClick()
    {
        ValidateName();

        if (NameError is not null)
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

    private void ValidateName()
    {
        if (string.IsNullOrEmpty(EventData.Name) || EventData.Name.Length < 3)
        {
            NameError = "Имя должно содержать минимум 3 символа";
        }
        else
        {
            NameError = null;
        }
    }
}