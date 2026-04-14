namespace CakeTime.Presentation.Models;

public sealed class MonthItem
{
    public required int Number { get; set; }
    public required string Name { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is MonthItem other)
        {
            return Number == other.Number;
        }

        return false;
    }

    public override int GetHashCode() => Number.GetHashCode();
}