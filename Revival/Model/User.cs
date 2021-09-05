using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Revival
{
    public class User : INotifyPropertyChanged
    {
        public int Id { get; private set; } = 0;

        private string _firstName;
        public string FirstName { get => _firstName;
            set
            {
                _firstName = value;
                NotifyPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName { get => _lastName;
            set
            {
                _lastName = value;
                NotifyPropertyChanged();
            }
        }

        private string _phoneNumber;

        public string PhoneNumber { get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _birthDate;

        public DateTime BirthDate { get => _birthDate;
            set
            {
                _birthDate = value;
                NotifyPropertyChanged();
            }
        }

        private Address _address;

        public Address Address { get => _address;
            set
            {
                _address = value;
                NotifyPropertyChanged();
            }
        }

        public User(string nickname, string username, string phoneNumber = "")
        {
            FirstName = nickname;
            LastName = username;
            PhoneNumber = phoneNumber;
        }

        public User(string nickname, string username, string phoneNumber, Address address): this(nickname, username, phoneNumber)
        {
            Address = address;
        }

        public User()
        {
            BirthDate = new DateTime(DateTime.Today.Ticks);
            Address = new();
        }

        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{FirstName} {LastName} {PhoneNumber}";
        }

        public void Initialize()
        {
            Id = new Random().Next(1, 10000);
        }
    }
}
