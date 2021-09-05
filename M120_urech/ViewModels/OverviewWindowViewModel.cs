using M120_urech.Commands;
using M120_urech.Models;
using M120_urech.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace M120_urech.ViewModels
{
    public class OverviewWindowViewModel : INotifyPropertyChanged
    {
        public Cinema Cinema { get; }

        private string _searchTerm = "";
        public string SearchTerm { get => _searchTerm;
            set
            {
                _searchTerm = value;
                SearchFilms(_searchTerm);
                NotifyPropertyChanged();
            }
        }

        private List<Film> _filteredFilms;
        public List<Film> FilteredFilms {
            get => _filteredFilms;
            set
            {
                _filteredFilms = value;
                NotifyPropertyChanged();
            }
        }

        private Film _selectedFilm;
        public Film SelectedFilm { get => _selectedFilm;
            set
            {
                _selectedFilm = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand OpenOrderWindowForFilm { get; }

        public OverviewWindowViewModel(Cinema cinema)
        {
            Cinema = cinema;

            OpenOrderWindowForFilm = new RelayCommand(payload =>
            {
                OrderWindow orderWindow = new OrderWindow(SelectedFilm);
                orderWindow.Show();
            }, a =>
            {
                return SelectedFilm != null;
            });

            FilteredFilms = new List<Film>(cinema.FilmList);
        }

        private void SearchFilms(string searchTerm)
        {
            FilteredFilms = new List<Film>(Cinema.FindFilmsByName(searchTerm));
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Static List of prepared film-entities.
        /// </summary>
        public static IEnumerable<Film> Library = new List<Film>
        {
            {
                new Film(
                    "The Avengers",
                    new Category("Action"),
                    155,
                    new List<Presentation>
                    {
                        { new Presentation(new DateTime(2021, 7, 24, 13, 45, 00), 120) },
                        { new Presentation(new DateTime(2021, 8, 24, 15, 00, 00), 120) },
                        { new Presentation(new DateTime(2021, 9, 24, 13, 45, 00), 120) },
                    }
                )
            },{
                new Film(
                    "The Dark Knight",
                    new Category("Actionthriller"),
                    170,
                    new List<Presentation>
                    {
                        { new Presentation(new DateTime(2021, 7, 26, 15, 45, 00), 120) },
                        { new Presentation(new DateTime(2021, 7, 28, 20, 00, 00), 120) },
                        { new Presentation(new DateTime(2021, 7, 30, 13, 00, 00), 120) },
                        { new Presentation(new DateTime(2021, 8, 3, 19, 45, 00), 120) },
                        { new Presentation(new DateTime(2021, 8, 5, 20, 00, 00), 120) },
                    }
                )
            },{
                new Film(
                    "No country for old men",
                    new Category("Actionthriller"),
                    110,
                    new List<Presentation>
                    {
                        { new Presentation(new DateTime(2021, 6, 12, 15, 45, 00), 120) },
                        { new Presentation(new DateTime(2021, 7, 12, 11, 45, 00), 120) },
                        { new Presentation(new DateTime(2021, 7, 18, 16, 30, 00), 120) },
                    }
                )
            },{
                new Film(
                    "Don jon",
                    new Category("Romance"),
                    132,
                    new List<Presentation>
                    {
                        { new Presentation(new DateTime(2021, 4, 24, 17, 00, 00), 120) },
                        { new Presentation(new DateTime(2021, 5, 24, 13, 30, 00), 120) },
                        { new Presentation(new DateTime(2021, 6, 24, 15, 45, 00), 120) },
                        { new Presentation(new DateTime(2021, 7, 24, 20, 45, 00), 120) },
                        { new Presentation(new DateTime(2021, 8, 24, 19, 30, 00), 120) },
                        { new Presentation(new DateTime(2021, 9, 24, 15, 45, 00), 120) },
                    }
                )
            },
        };
    }
}
