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

namespace Project.ViewModel
{
    public class AccountViewModel : ValidatableObject, INotifyPropertyChanged
    {
        private bool _CanAddNewAccount = false;

        private List<Bank> allbanks = Controller.GetBanks();
        public List<Bank> AllBanks
        {
            get { return allbanks; }
            set
            {
                allbanks = value;
                NotifyPropertyChanged("AllBanks");
            }
        }
        private List<AccountType> allaccounttypes = Controller.GetAccountTypes();
        public List<AccountType> AllAccountTypes
        {
            get { return allaccounttypes; }
            set
            {
                allaccounttypes = value;
                NotifyPropertyChanged("AllAccountTypes");
            }
        }
        private List<Aggrement> allaggrements = Controller.GetAggrements();
        public List<Aggrement> AllAggrements
        {
            get { return allaggrements; }
            set
            {
                allaggrements = value;
                NotifyPropertyChanged("AllAggrements");
            }
        }

        #region AccountProperties
        private Bank bank;
        private Aggrement aggrement;
        private AccountType accounttype;
        private string accountnumber;
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Банк'")]
        public Bank AccountBank
        {
            get { return bank; }
            set
            {
                bank = value;
                NotifyPropertyChanged("AccountBank");
            }
        }
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Договор'")]
        public Aggrement AccountAggrement
        {
            get { return aggrement; }
            set
            {
                aggrement = value;
                NotifyPropertyChanged("AccountAggrement");
            }
        }
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Тип счета'")]
        public AccountType AccountAccountType
        {
            get { return accounttype; }
            set
            {
                accounttype = value;
                NotifyPropertyChanged("AccountAccountType");
            }
        }
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Номер Счета'")]
        public string AccountNumber
        {
            get { return accountnumber; }
            set
            {
                accountnumber = value;
                NotifyPropertyChanged("AccountNumber");
            }
        }
        #endregion

        public AccountViewModel(Account SelectedAccount)
        {
            Validator = GetValidator();
        }

        public AccountViewModel()
        {
            Validator = GetValidator();
        }
        public IObjectValidator GetValidator()
        {
            ValidationBuilder<AccountViewModel> builder = new ValidationBuilder<AccountViewModel>();
            builder.RuleFor(vm => vm.AccountAggrement).NotNull();
            builder.RuleFor(vm => vm.AccountBank).NotNull();
            builder.RuleFor(vm => vm.AccountAccountType).NotNull();
            if (builder.Build(this).IsValid == true)
                _CanAddNewAccount = true;
            else
                _CanAddNewAccount = false;
            return builder.Build(this);
        }

        private RelayCommand addNewAccount;
        public RelayCommand AddNewAccount
        {
            get
            {
                return addNewAccount ?? new RelayCommand(obj =>
                {
                    GetValidator();
                    if (_CanAddNewAccount)
                    {
                        Window wnd = obj as Window;
                        Controller.CreateAccount(AccountNumber,AccountBank,AccountAggrement,AccountAccountType);
                        wnd.Close();
                        SetNullsOnProperties();
                    }
                    else if (_CanAddNewAccount == false)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        public static string AccountNumber2 { get; set; }
       

        public static Account SelectedAccount { get; set; }

        private RelayCommand editAccount;
        public RelayCommand EditAccount
        {
            get
            {
                return editAccount ?? new RelayCommand(obj =>
                {
                    GetValidator();
                    if (_CanAddNewAccount)
                    {
                        Window wnd = obj as Window;
                        if (SelectedAccount != null)
                        {
                            Controller.EditAccount(SelectedAccount, AccountNumber2, AccountBank, AccountAggrement, AccountAccountType);
                            wnd.Close();
                        }
                        else { MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
                    }
                    else if (_CanAddNewAccount == false)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                });
            }
        }

        private void SetNullsOnProperties()
        {
            AccountBank = null;
            AccountAggrement = null;
            AccountAccountType = null;
            AccountNumber = null;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
