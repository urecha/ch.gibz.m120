using M120_urech.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace M120_urech
{
    public class PresentationFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Presentation)) return value.ToString();
            Presentation presentation = value as Presentation;
            return $"{presentation.PresentationTime.ToShortDateString()} | {presentation.FreePlacesCount} places left";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
