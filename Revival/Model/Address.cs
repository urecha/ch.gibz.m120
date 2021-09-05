using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Revival
{
    public class Address : INotifyPropertyChanged
    {
        private string _street;
        private string _zip;
        private string _city;
        private string _country;

        public string Street { get => _street;
            set
            {
                _street = value;
                NotifyPropertyChanged();
            }
        }
        public string ZIP
        {
            get => _zip;
            set
            {
                _zip = value;
                NotifyPropertyChanged();
            }
        }
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                NotifyPropertyChanged();
            }
        }

        public string Country { get => _country;
            set
            {
                _country = value;
                NotifyPropertyChanged();
            }
        }

        public Address()
        {

        }

        public Address(string street, string zip, string location, string country)
        {
            Street = street;
            ZIP = zip;
            City = location;
            Country = country;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Street}, {ZIP} {City}, {Country}";
        }
    }
}
