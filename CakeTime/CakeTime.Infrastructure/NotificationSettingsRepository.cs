using CakeTime.Domain;

namespace CakeTime.Infrastructure;

public sealed class NotificationSettingsRepository : INotificationSettingsRepository
{
    private readonly LocalDBService _localDBService;

    public NotificationSettingsRepository() => _localDBService = new LocalDBService();

    public async Task<List<NotificationSetting>> GetSettingsAsync() =>
        await _localDBService.Connection.Table<NotificationSetting>().ToListAsync();

    public async Task AddSettingsAsync(NotificationSetting settings) =>
        await _localDBService.Connection.InsertAsync(settings);

    public async Task UpdateSettingsAsync(NotificationSetting settings) =>
        await _localDBService.Connection.UpdateAsync(settings);

    public async Task DeleteSettingsAsync(NotificationSetting settings) =>
        await _localDBService.Connection.DeleteAsync(settings);
}