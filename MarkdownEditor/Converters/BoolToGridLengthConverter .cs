using Avalonia.Controls;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace MarkdownEditor.Converters
{
    public class BoolToGridLengthConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is false ? new GridLength(0) : new GridLength(1, GridUnitType.Star);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
