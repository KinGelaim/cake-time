namespace CakeTime.Domain;

public interface INotificationSettingsRepository
{
    public Task<List<NotificationSetting>> GetSettingsAsync();
    public Task AddSettingsAsync(NotificationSetting settings);
    public Task UpdateSettingsAsync(NotificationSetting settings);
    public Task DeleteSettingsAsync(NotificationSetting settings);
}