using Revival.Commandos;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Revival
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<DebugMessage> Messages { get; set; } = new ObservableCollection<DebugMessage>();

        private User _selectedUser;
        public User SelectedUser { get => _selectedUser;
            set
            {
                _selectedUser = value;
                NotifyPropertyChanged();
            }
        }

        private int _sliderValue;
        public int SliderValue {
            get => _sliderValue;
            set {
                _sliderValue = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommando SelectUser { get; private set; }
        public RelayCommando EditUser { get; private set; }
        public RelayCommando CreateUser { get; private set; }
        public RelayCommando AddUser { get; private set; }
        public RelayCommando DeleteUser { get; private set; }

        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            SliderValue = 0;

            SelectUser = new RelayCommando(payload =>
            {
                if (!(payload is User)) return;
                SelectedUser = (User)payload;
            });

            EditUser = new RelayCommando(payload =>
            {
                SelectedUser = (User)payload;
            }, a =>
            {
                return SelectedUser != null;
            });

            CreateUser = new RelayCommando(payload =>
            {
                SelectedUser = new User();
            }, a =>
            {
                return true;
            });

            AddUser = new RelayCommando(payload =>
            {
                User user = (User)payload;
                if(user.Id != 0)
                {
                    SelectedUser = null;
                    return;
                }
                user.Initialize();
                Users.Add(user);
                SelectedUser = null;
            }, a =>
            {
                return SelectedUser == null
                    || (SelectedUser.FirstName != ""
                    && SelectedUser.LastName != ""
                    && SelectedUser.PhoneNumber != "");
            });

            DeleteUser = new RelayCommando(payload =>
            {
                Users.Remove((User)payload);
                SelectedUser = null;
            }, a =>
            {
                return SelectedUser != null;
            });
        }

        public void Log(string message)
        {
            Messages.Add(new DebugMessage(message));
        }
    }
}
