using M120_urech.Models;
using M120_urech.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M120_urech.Windows
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow(Film film)
        {
            InitializeComponent();
            OrderWindowViewModel orderContext = new OrderWindowViewModel(film);
            orderContext.Close = new Commands.RelayCommand(
                payload => this.Close(), 
                a => true);
            this.DataContext = orderContext;
        }

        private static readonly Regex _numeric = new Regex("[0-9]+");

        private void Tickets_Input_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !_numeric.IsMatch(e.Text);
        }
    }
}
