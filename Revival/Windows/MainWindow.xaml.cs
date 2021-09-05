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

namespace Revival
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel context = new();
            DataContext = context;
        }

        /**
        Outsource clik handlers by binding visibility to some field in ViewModel.
        Or use more windoos
         */

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel context = (MainViewModel)DataContext;
            context.Log("Edit");
            listview.Visibility = Visibility.Collapsed;
            aeditmodal.Visibility = Visibility.Visible;
        }

        private void Aedit_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel context = (MainViewModel)DataContext;
            context.Log("Aedit");
            listview.Visibility = Visibility.Visible;
            aeditmodal.Visibility = Visibility.Collapsed;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel context = (MainViewModel)DataContext;
            context.Log("Create");
            listview.Visibility = Visibility.Collapsed;
            aeditmodal.Visibility = Visibility.Visible;
        }

        private void SlidinText_TextInput(object sender, TextCompositionEventArgs e)
        {
            MainViewModel context = (MainViewModel)DataContext;
            context.SliderValue = Int32.Parse(e.Text);
        }

        private void UserTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainViewModel context = (MainViewModel)DataContext;
            context.Log("Selection changed");
            if (!(userTable.SelectedItem is User))
            {
                context.Log("Selected item != user");
                return;
            }
            context.SelectedUser = (User)userTable.SelectedItem;
            context.Log($"Selected user: {context.SelectedUser}");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            listview.Visibility = Visibility.Visible;
            aeditmodal.Visibility = Visibility.Collapsed;
        }
    }
}
