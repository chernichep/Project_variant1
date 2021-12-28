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

namespace Project.View.Adding
{
    /// <summary>
    /// Interaction logic for AddNewAggrement.xaml
    /// </summary>
    public partial class AddNewAggrement : Window
    {
        public AddNewAggrement()
        {
            InitializeComponent();
            DataContext = new AggrementViewModel();
        }
    }
}
