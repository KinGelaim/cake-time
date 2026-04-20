using SQLite;

namespace CakeTime.Domain;

[Table("notification_settings")]
public sealed class NotificationSetting
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("days_count_before_event")]
    public int DaysCountBeforeEvent { get; set; }

    [Column("first_notification_hour")]
    public int FirstNotificationHour { get; set; }

    [Column("notification_count")]
    public int NotificationCount { get; set; }

    [Column("minutes_interval")]
    public int MinutesInterval { get; set; }
}