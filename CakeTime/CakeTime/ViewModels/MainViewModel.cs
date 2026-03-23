using CakeTime.Environment;
using CakeTime.Views;

namespace CakeTime.ViewModels;

public partial class MainViewModel : NotificationObject
{
    public EmptyEventListContent EmptyEventListContent { get; } = new EmptyEventListContent();
    public EventListContent EventListContent { get; } = new EventListContent();
    public CalendarContent CalendarContent { get; } = new CalendarContent();
    public SettingsContent SettingsContent { get; } = new SettingsContent();

    public DelegateCommand ShowEmptyEventListContentCommand { get; }
    public DelegateCommand ShowCalendarContentCommand { get; }
    public DelegateCommand ShowSettingsContentCommand { get; }

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
}