using CakeTime.Application;
using CakeTime.Infrastructure.Environment;
using CakeTime.Presentation.Views;

namespace CakeTime.Presentation.ViewModels;

public partial class MainViewModel : NotificationObject
{
    public EmptyEventListContent EmptyEventListContent { get; } = new EmptyEventListContent();
    public EventListContent EventListContent { get; }
    public CalendarContent CalendarContent { get; } = new CalendarContent();
    public SettingsContent SettingsContent { get; } = new SettingsContent();
    public EventAddContent EventAddContent { get; }
    public EventEditContent EventEditContent { get; } = new EventEditContent();

    public DelegateCommand ShowEmptyEventListContentCommand { get; }
    public DelegateCommand ShowCalendarContentCommand { get; }
    public DelegateCommand ShowSettingsContentCommand { get; }
    public DelegateCommand ShowEventAddContentCommand { get; }
    public DelegateCommand ShowEventEditContentCommand { get; }

    private View _currentContent;
    public View CurrentContent
    {
        get => _currentContent;
        set
        {
            _currentContent = value;
            OnPropertyChanged(nameof(CurrentContent));
        }
    }

    private readonly EventService _eventService;

    public MainViewModel(EventService eventService)
    {
        _eventService = eventService;

        Task.Run(() => _eventService.LoadEventsAsync())
            .ContinueWith(t =>
            {
                if (!t.IsCompletedSuccessfully)
                {
                    return;
                }

                CurrentContent = GetCurrentEventListContent();
            });

        var eventsListViewModel = new EventsListViewModel(_eventService);
        var eventAddViewModel = new EventAddViewModel(_eventService);
        eventAddViewModel.OnCloseBtnClick += OnEventListImageClick;

        EventListContent = new EventListContent(eventsListViewModel);
        EventAddContent = new EventAddContent(eventAddViewModel);

        _eventService.EventsChanged += CheckCurrentEventListContent;

        _currentContent = GetCurrentEventListContent();

        ShowEmptyEventListContentCommand = new DelegateCommand(OnEventListImageClick);
        ShowCalendarContentCommand = new DelegateCommand(OnCalendarImageClick);
        ShowSettingsContentCommand = new DelegateCommand(OnSettingsImageClick);
        ShowEventAddContentCommand = new DelegateCommand(OnEventAddImageClick);
        ShowEventEditContentCommand = new DelegateCommand(OnEventEditClick);
    }

    private ContentView GetCurrentEventListContent() =>
        _eventService.Events.Count > 0
            ? EventListContent
            : EmptyEventListContent;

    private void CheckCurrentEventListContent()
    {
        var newContent = GetCurrentEventListContent();
        if (newContent != CurrentContent)
        {
            CurrentContent = newContent;
        }
    }

    private void OnEventListImageClick() => CurrentContent = GetCurrentEventListContent();

    private void OnCalendarImageClick() => CurrentContent = CalendarContent;

    private void OnSettingsImageClick() => CurrentContent = SettingsContent;

    private void OnEventAddImageClick() => CurrentContent = EventAddContent;

    private void OnEventEditClick() => CurrentContent = EventEditContent;
}