using System;
using System.Globalization;
using System.Windows.Data;

namespace M120_urech
{
    public class PriceFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is float)) return value.ToString();
            return $"{value.ToString()}.-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
