using CakeTime.Environment;
using CakeTime.Views;

namespace CakeTime.ViewModels;

public partial class MainViewModel : NotificationObject
{
    public EmptyEventListContent EmptyEventListContent { get; } = new EmptyEventListContent();
    public EventListContent EventListContent { get; } = new EventListContent();

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
        _currentContent = EventListContent;
    }
}