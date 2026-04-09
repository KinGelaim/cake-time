using System.Globalization;

namespace CakeTime.Presentation.Converters;

public sealed class BoolToVisibleOrHiddenConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolVal && boolVal)
        {
            return true;
        }
        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolVal)
        {
            return boolVal;
        }
        return false;
    }
}