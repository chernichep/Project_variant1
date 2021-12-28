using System;
using System.Collections.Generic;
using System.Text;
using Project.Model;
using System.ComponentModel;
using Project.Query;
using System.Windows.Controls;
using Project.View.Adding;
using Project.View.Editing;
using System.Windows;
using System.Windows.Media;
using ReactiveValidation;
using ReactiveValidation.Extensions;
using ReactiveValidation.Attributes;
using Project.View;

namespace Project.ViewModel
{
    public class ProjectViewModel : ValidatableObject, INotifyPropertyChanged
    {

        private List<Account> accounts = Controller.GetAccounts();
        private static List<Aggrement> aggrements = Controller.GetAggrements();
        private static List<AccountType> accounttypes = Controller.GetAccountTypes();
        private static List<Bank> banks = Controller.GetBanks();

        public ProjectViewModel()
        {

        }
        public List<Account> Accounts
        {
            get { return accounts; }
            set { accounts = value; NotifyPropertyChanged("Accounts"); }
        }

        public List<Aggrement> Aggrements
        {
            get { return aggrements; }
            set { aggrements = value; NotifyPropertyChanged("Aggrements"); }
        }
        public List<Bank> Banks
        {
            get { return banks; }
            set { banks = value; NotifyPropertyChanged("Banks"); }
        }
        public List<AccountType> AccountTypes
        {
            get { return accounttypes; }
            set { accounttypes = value; NotifyPropertyChanged("AccountTypes"); }
        }

        public static string NameFull { get; set; }
        public static string NameShort { get; set; }
        public static  string Inn { get; set; }
        public static string Bik { get; set; }
        public static string KorAccount { get; set; }
        public static string AccounNumber { get; set; }
        public static string City { get; set; }


        public static string Type { get; set; }

        public TabItem SelectedTab { get; set; }
        public static Account SelectedAccount { get; set; }
        public static AccountType SelectedType { get; set; }
        public static Aggrement SelectedAggrement { get; set; }
        public static Bank SelectedBank { get; set; }

        public static string AccountNumber2 { get; set; }

        public static string Number { get; set; }
        public static string DateOpen { get; set; }
        public static string DataClose { get; set; }
        public static string Notes { get; set; }

 



        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    if (SelectedTab != null)
                    {
                        if (SelectedTab.Name == "BankTab" && SelectedBank != null)
                            Controller.DeleteBank(SelectedBank);
                        if (SelectedTab.Name == "AccountTypeTab" && SelectedType != null)
                            Controller.DeleteAccountType(SelectedType);
                        if (SelectedTab.Name == "AggrementTab" && SelectedAggrement != null)
                            Controller.DeleteAggrement(SelectedAggrement);
                        if (SelectedTab.Name == "AccountTab" && SelectedAccount != null)
                            Controller.DeleteAccount(SelectedAccount);
                    }
                    else 
                        MessageBox.Show("Не выбрана вкладка", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateAll();
                });

            }
        }
        private RelayCommand addItem;
        public RelayCommand AddItem
        {
            get
            {
                return addItem ?? new RelayCommand(obj =>
                {
                    if (SelectedTab != null)
                    {
                        if (SelectedTab.Name == "BankTab")
                        {
                            AddNewBank bankWindow = new AddNewBank();
                            bankWindow.ShowDialog();
                        }

                        if (SelectedTab.Name == "AccountTypeTab")
                        {
                            AddNewType typeWindow = new AddNewType();
                            typeWindow.ShowDialog();
                        }

                        if (SelectedTab.Name == "AggrementTab")
                        {
                            AddNewAggrement aggrementWindow = new AddNewAggrement();
                            aggrementWindow.ShowDialog();
                        }

                        if (SelectedTab.Name == "AccountTab")
                        {
                            AddNewAccount accountWindow = new AddNewAccount();
                            accountWindow.ShowDialog();
                        }
                    }
                    else
                        MessageBox.Show("Не выбрана вкладка", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateAll();
                });

            }
        }
        
        private RelayCommand editITem;
        public RelayCommand EditITem
        {
            get
            {
                return editITem ?? new RelayCommand(obj =>
                {
                    if (SelectedTab != null)
                        {
                            if (SelectedTab.Name == "BankTab" && SelectedBank != null)
                            {
                                EditBank bankWindow = new EditBank(SelectedBank);
                                
                                bankWindow.ShowDialog();
                            }

                            if (SelectedTab.Name == "AccountTypeTab" && SelectedType != null)
                            {
                                EditType typeWindow = new EditType(SelectedType);
                                typeWindow.ShowDialog();
                            }

                            if (SelectedTab.Name == "AggrementTab" && SelectedAggrement != null)
                            {
                                EditAggrement accountWindow = new EditAggrement(SelectedAggrement);
                                accountWindow.ShowDialog();
                            }

                            if (SelectedTab.Name == "AccountTab" && SelectedAccount != null)
                            {
                                EditAccount accountWindow = new EditAccount(SelectedAccount);
                                accountWindow.ShowDialog();
                            }
                        }
                        else
                        MessageBox.Show("Не выбрана вкладка", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateAll();
                });

            }
        }


        public void UpdateAll()
        {
            UpdateAllAccounts();
            UpdateAllAccountTypes();
            UpdateAllAggrements();
            UpdateAllBanks();
        }
        #region UpdatesMethods
        public void UpdateAllAccounts()
        {
            Accounts = Controller.GetAccounts();
            MainWindow.Accounts.ItemsSource = null;
            MainWindow.Accounts.Items.Clear();
            MainWindow.Accounts.ItemsSource = Accounts;
            MainWindow.Accounts.Items.Refresh();
        }
        private void UpdateAllAggrements()
        {
            Aggrements = Controller.GetAggrements();
            MainWindow.AllAggrements.ItemsSource = null;
            MainWindow.AllAggrements.Items.Clear();
            MainWindow.AllAggrements.ItemsSource = Aggrements;
            MainWindow.AllAggrements.Items.Refresh();
        }
        private void UpdateAllAccountTypes()
        {
            AccountTypes = Controller.GetAccountTypes();
            MainWindow.AllTypes.ItemsSource = null;
            MainWindow.AllTypes.Items.Clear();
            MainWindow.AllTypes.ItemsSource = AccountTypes;
            MainWindow.AllTypes.Items.Refresh();
        }
        private void UpdateAllBanks()
        {
            Banks = Controller.GetBanks();
            MainWindow.AllBanks.ItemsSource = null;
            MainWindow.AllBanks.Items.Clear();
            MainWindow.AllBanks.ItemsSource = Banks;
            MainWindow.AllBanks.Items.Refresh();
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
