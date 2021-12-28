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
using Project.Query;
using Project.Model;
using Project.View.Adding;
using Project.View.Editing;
using Project.ViewModel;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace Project.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// \

    public partial class MainWindow : Window
    {
        public static DataGrid Accounts;
        public static DataGrid AllBanks;
        public static DataGrid AllTypes;
        public static DataGrid AllAggrements;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ProjectViewModel();
            Accounts = AccountGrid;
            AllTypes = DataGridAccountTypes; 
            AllBanks = BankDataGrid;
            AllAggrements= AggrementDataGrid;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
