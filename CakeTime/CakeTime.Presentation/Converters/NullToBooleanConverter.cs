using System.Globalization;

namespace CakeTime.Presentation.Converters;

public sealed class NullToBooleanConverter : IValueConverter
{
    public bool Invert { get; set; } = false;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var result = value is not null;
        return Invert ? !result : result;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}