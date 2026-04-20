using CakeTime.Domain;

namespace CakeTime.Application;

public sealed class NotificationSettingsService(
    INotificationSettingsRepository notificationSettingsRepository)
{
    private readonly INotificationSettingsRepository _notificationSettingsRepository = notificationSettingsRepository;

    public List<NotificationSetting> NotificationSettings { get; private set; } = [];

    public event Action? SettingsChanged;

    public async Task<List<NotificationSetting>> LoadSettingsAsync() =>
        NotificationSettings = await GetSettingsAsync();

    private async Task<List<NotificationSetting>> GetSettingsAsync() =>
        await _notificationSettingsRepository.GetSettingsAsync();

    public async Task UpdateSettings(NotificationSetting[] notificationSettings)
    {
        foreach (var settings in notificationSettings)
        {
            if (settings.Id == 0)
            {
                await AddSettingsAsync(settings);
            }
            else
            {
                await UpdateSettingsAsync(settings);
            }
        }
    }

    public async Task AddSettingsAsync(NotificationSetting settings)
    {
        await _notificationSettingsRepository.AddSettingsAsync(settings);
        await LoadSettingsAsync();
        SettingsChanged?.Invoke();
    }

    public async Task UpdateSettingsAsync(NotificationSetting settings)
    {
        await _notificationSettingsRepository.UpdateSettingsAsync(settings);
        await LoadSettingsAsync();
        SettingsChanged?.Invoke();
    }

    public async Task DeleteSettingsAsync(int id)
    {
        var settings = NotificationSettings.FirstOrDefault(x => x.Id == id);
        if (settings is not null)
        {
            await _notificationSettingsRepository.DeleteSettingsAsync(settings);
            await LoadSettingsAsync();
            SettingsChanged?.Invoke();
        }
    }

    // TODO: temporary method
    public async Task ClearTable()
    {
        await LoadSettingsAsync();
        foreach (var settings in NotificationSettings)
        {
            await _notificationSettingsRepository.DeleteSettingsAsync(settings);
        }
        await LoadSettingsAsync();
        SettingsChanged?.Invoke();
    }
}