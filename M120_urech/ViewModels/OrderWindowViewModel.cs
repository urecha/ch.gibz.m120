using M120_urech.Commands;
using M120_urech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace M120_urech.ViewModels
{
    public class OrderWindowViewModel : INotifyPropertyChanged
    {
        public Film Film { get; }

        private Visibility _dialogVisibility = Visibility.Visible;
        public Visibility DialogVisibility {
            get => _dialogVisibility;
            set
            {
                _dialogVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private Visibility _endScreenVisibility = Visibility.Hidden;
        public Visibility EndScreenVisibility { 
            get => _endScreenVisibility;
            set
            {
                _endScreenVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private Presentation _selectedPresentation;
        public Presentation SelectedPresentation { 
            get => _selectedPresentation;
            set
            {
                _selectedPresentation = value;
                if(TicketsOrdered > _selectedPresentation.FreePlacesCount)
                {
                    TicketsOrdered = _selectedPresentation.FreePlacesCount;
                }
                NotifyPropertyChanged();
            }
        }

        private int _ticketsOrdered = 0;
        public int TicketsOrdered { 
            get => _ticketsOrdered;
            set
            {
                if (SelectedPresentation != null)
                {
                    if(value > SelectedPresentation.FreePlacesCount)
                    {
                        value = SelectedPresentation.FreePlacesCount;
                    } else if (value < 0)
                    {
                        TicketsOrdered = value * -1;
                        return;
                    }
                }
                if (value == null || !(value is int)) value = 0;

                _ticketsOrdered = value;
                TotalPrice = _ticketsOrdered * Film.PRICE_PER_TICKET;
                NotifyPropertyChanged();

            }
        }

        private float _totalPrice = 0;
        public float TotalPrice {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand Confirm { get; }
        public RelayCommand Close { get; set; }

        public OrderWindowViewModel(Film selectedFilm)
        {
            Film = selectedFilm;
            SelectedPresentation = Film.Presentations.FirstOrDefault();

            Confirm = new RelayCommand(payload =>
            {
                SelectedPresentation.FreePlacesCount -= TicketsOrdered;
                DialogVisibility = Visibility.Hidden;
                EndScreenVisibility = Visibility.Visible;
            }, a =>
            {
                return TotalPrice != 0 && !float.IsInfinity(TotalPrice);
            });

            Close = new RelayCommand(payload =>
            {
                if(!(payload is Window)) return;
                ((Window)payload).Close();
            }, a =>
            {
                return true;
            });
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
