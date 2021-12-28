using System.Windows;
using Project.ViewModel;

namespace Project.View.Adding
{
    /// <summary>
    /// Interaction logic for AddNewBank.xaml
    /// </summary>
    public partial class AddNewBank : Window
    {
        public AddNewBank()
        {
            InitializeComponent();
            DataContext = new BankViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewBankButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
        }
    }
}
