using SQLite;

namespace CakeTime.Domain;

[Table("events")]
public sealed class EventData
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("day")]
    public int Day { get; set; }

    [Column("month")]
    public int Month { get; set; }

    [Column("year")]
    public int? Year { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }
}