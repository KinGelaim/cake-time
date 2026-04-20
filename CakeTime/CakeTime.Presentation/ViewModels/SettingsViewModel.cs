using CakeTime.Application;
using CakeTime.Domain;
using CakeTime.Infrastructure.Environment;
using CakeTime.Presentation.Models;
using System.Collections.ObjectModel;

namespace CakeTime.Presentation.ViewModels;

public sealed class SettingsViewModel : NotificationObject
{
    private readonly NotificationSettingsService _notificationSettingsService;

    public ObservableCollection<NotificationSettingsView> SettingsGroups
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged(nameof(SettingsGroups));
        }
    } = [];

    public DelegateCommand AddNewGroupCommand { get; }
    public DelegateCommand SaveSettingsCommand { get; }

    public SettingsViewModel(NotificationSettingsService notificationSettingsService)
    {
        _notificationSettingsService = notificationSettingsService;

        AddNewGroupCommand = new DelegateCommand(OnAddNewGroupBtnClick);
        SaveSettingsCommand = new DelegateCommand(OnSaveSettingsBtnClick);

        _notificationSettingsService.SettingsChanged += LoadSettings;

        Task.Run(() => _notificationSettingsService.LoadSettingsAsync())
            .ContinueWith(t =>
            {
                if (!t.IsCompletedSuccessfully)
                {
                    return;
                }

                LoadSettings();
            });
    }

    private void LoadSettings()
    {
        SettingsGroups.Clear();
        foreach (var settings in _notificationSettingsService.NotificationSettings)
        {
            SettingsGroups.Add(new NotificationSettingsView()
            {
                Id = settings.Id,
                DaysCountBeforeEvent = settings.DaysCountBeforeEvent,
                FirstNotificationHour = settings.FirstNotificationHour,
                NotificationCount = settings.NotificationCount,
                MinutesInterval = settings.MinutesInterval
            });
        }
    }

    private void OnAddNewGroupBtnClick() => SettingsGroups.Add(new NotificationSettingsView());

    private void OnSaveSettingsBtnClick()
    {
        // TODO: Validate
        var settings = SettingsGroups
            .Select(x => new NotificationSetting()
            {
                Id = x.Id ?? 0,
                DaysCountBeforeEvent = x.DaysCountBeforeEvent ?? 0,
                FirstNotificationHour = x.FirstNotificationHour ?? 14,
                NotificationCount = x.NotificationCount ?? 3,
                MinutesInterval = x.MinutesInterval ?? 10
            })
            .ToArray();
        Task.Run(() => _notificationSettingsService.UpdateSettings(settings));
    }
}