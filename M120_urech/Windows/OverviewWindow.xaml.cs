using M120_urech.Models;
using M120_urech.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120_urech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OverviewWindow : Window
    {
        public OverviewWindow()
        {
            InitializeComponent();
            Cinema cinema = new Cinema();
            cinema.FilmList = OverviewWindowViewModel.Library;
            OverviewWindowViewModel context = new OverviewWindowViewModel(cinema);
            this.DataContext = context;
        }
    }
}
