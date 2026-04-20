namespace CakeTime.Presentation.Models;

public sealed class NotificationSettingsView
{
    public int? Id { get; set; }

    public int? DaysCountBeforeEvent { get; set; }

    public int? FirstNotificationHour { get; set; }

    public int? NotificationCount { get; set; }

    public int? MinutesInterval { get; set; }
}