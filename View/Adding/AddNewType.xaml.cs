﻿using System;
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
using Project.ViewModel;

namespace Project.View.Adding
{
    /// <summary>
    /// Interaction logic for AddNewType.xaml
    /// </summary>
    public partial class AddNewType : Window
    {
        public AddNewType()
        {
            InitializeComponent();
            DataContext = new AccountTypeViewModel();
        }
    }
}
