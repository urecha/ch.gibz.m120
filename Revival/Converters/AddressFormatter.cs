using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Revival
{
    public class AddressFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            #region implementation
            if (!(value is Address)) return value.ToString();
            Address address = value as Address;

            return $"{address.Street}\n{address.ZIP} {address.City}\n{address.Country}";
            #endregion
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            #region implementation
            if (!(value is string)) throw new ArgumentException("I can't handle this!");
            string addressString = value as string;

            try
            {
                Address address = new Address();
                string[] parts = addressString.Trim().Split('\n');
                address.Street = parts[0];
                address.Country = parts[2];

                string[] zipAndCity = parts[1].Trim().Split(' ');
                address.ZIP = zipAndCity[0];
                address.City = zipAndCity[1];
                return address;
            } catch (Exception e)
            {
                throw new ArgumentException("Please format the address properly!");
            }
            #endregion
        }
    }

    public class NameFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
