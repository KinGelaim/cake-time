using CakeTime.Environment;
using CakeTime.Views;

namespace CakeTime.ViewModels;

public partial class MainViewModel : NotificationObject
{
    public EmptyEventListContent EmptyEventListContent { get; } = new EmptyEventListContent();
    public EventListContent EventListContent { get; } = new EventListContent();
    public CalendarContent CalendarContent { get; } = new CalendarContent();
    public SettingsContent SettingsContent { get; } = new SettingsContent();
    public EventAddContent EventAddContent { get; } = new EventAddContent();
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

    public MainViewModel()
    {
        _currentContent = EmptyEventListContent;

        ShowEmptyEventListContentCommand = new DelegateCommand(OnEventListImageClick);
        ShowCalendarContentCommand = new DelegateCommand(OnCalendarImageClick);
        ShowSettingsContentCommand = new DelegateCommand(OnSettingsImageClick);
        ShowEventAddContentCommand = new DelegateCommand(OnEventAddImageClick);
        ShowEventEditContentCommand = new DelegateCommand(OnEventEditClick);
    }

    private void OnEventListImageClick()
    {
        CurrentContent = EmptyEventListContent;
    }

    private void OnCalendarImageClick()
    {
        CurrentContent = CalendarContent;
    }

    private void OnSettingsImageClick()
    {
        CurrentContent = SettingsContent;
    }

    private void OnEventAddImageClick()
    {
        CurrentContent = EventAddContent;
    }

    private void OnEventEditClick()
    {
        CurrentContent = EventEditContent;
    }
}