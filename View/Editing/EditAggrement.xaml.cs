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
    /// Interaction logic for EditAggrement.xaml
    /// </summary>
    public partial class EditAggrement : Window
    {
        public EditAggrement(Aggrement aggrementToEdit)
        {
            InitializeComponent();
            DataContext = new AggrementViewModel();
            AggrementViewModel.SelectedAggrement = aggrementToEdit;
            AggrementViewModel a = new AggrementViewModel();
            a.Number = aggrementToEdit.Number;
            a.DateOpen = aggrementToEdit.DateOpen;
            a.DataClose = aggrementToEdit.DataClose;
            a.Notes = aggrementToEdit.Notes;

        }
    }
}
