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
    /// Interaction logic for EditBank.xaml
    /// </summary>
    public partial class EditBank : Window
    {
        public EditBank(Bank bankToEdit)
        {
            InitializeComponent();
            DataContext = new BankViewModel();

            BankViewModel bank = new BankViewModel();
            BankViewModel.SelectedBank = bankToEdit;

            bank.NameFull = bankToEdit.NameFull;
            bank.NameShort = bankToEdit.NameShort;
            bank.Inn = bankToEdit.Inn;
            bank.Bik = bankToEdit.Bik;
            bank.KorAccount = bankToEdit.KorAccount;
            bank.AccounNumber = bankToEdit.AccounNumber;
            bank.City = bankToEdit.City;
        }
    }
}
