using System;
using System.Globalization;
using System.Windows.Data;

namespace M120_urech
{
    public class DurationFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int)) return value.ToString();
            return $"{value.ToString()} min";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
