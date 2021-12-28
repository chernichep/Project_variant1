using Project.Model;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.View.Editing
{
    /// <summary>
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        public EditAccount(Account accountToEdit)
        {
            InitializeComponent();
            DataContext = new AccountViewModel();
            AccountViewModel.SelectedAccount = accountToEdit;
            AccountViewModel.AccountNumber2 = accountToEdit.AccountNumber;
 
        }
    }
}
