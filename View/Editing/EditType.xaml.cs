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
    /// Interaction logic for EditType.xaml
    /// </summary>
    public partial class EditType : Window
    {
        public EditType(AccountType typeToEdit)
        {
            InitializeComponent();

            DataContext = new AccountTypeViewModel();

            AccountTypeViewModel actv = new AccountTypeViewModel();
            AccountTypeViewModel.SelectedType = typeToEdit;
            
            actv.Type = typeToEdit.Type;
        }
    }
}
