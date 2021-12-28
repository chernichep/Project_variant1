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
    public class BankViewModel : ValidatableObject, INotifyPropertyChanged
    {

        private bool _CanAddNewBank = false;

        #region BankProperties
        public static string namefull, nameshort, inn, bik, koraccount, accountnumber, city;
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Полное имя'")]
        public string NameFull
        {
            get { return namefull; }
            set
            {
                namefull = value;
                NotifyPropertyChanged("NameFull");
            }
        }
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Сокращенное имя'")]
        public string NameShort
        {
            get { return nameshort; }
            set
            {
                nameshort = value;
                NotifyPropertyChanged("NameShort");
            }
        }

        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'ИНН'")]
        public string Inn
        {
            get { return inn; }
            set
            {
                inn = value;
                NotifyPropertyChanged("Inn");
            }
        }

        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'БИК'")]
        public string Bik
        {
            get { return bik; }
            set
            {
                bik = value;
                NotifyPropertyChanged("Bik");
            }
        }

        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Кор.Счет'")]
        public string KorAccount
        {
            get { return koraccount; }
            set
            {
                koraccount = value;
                NotifyPropertyChanged("KorAccount");
            }
        }
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Номер счета'")]
        public string AccounNumber
        {
            get { return accountnumber; }
            set
            {
                accountnumber = value;
                NotifyPropertyChanged("AccounNumber");
            }
        }
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Город'")]
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                NotifyPropertyChanged("City");
            }
        }

        #endregion
        public BankViewModel()
        {
            Validator = GetValidator();
        }

        public static string NameFull2 { get; set; }
        public static string NameShort2 { get; set; }
        public static string Inn2 { get; set; }
        public static string Bik2 { get; set; }
        public static string Koraccount2 { get; set; }
        public static string AccountNumber2 { get; set; }
        public static string City2 { get; set; }
        public IObjectValidator GetValidator()
        {
            ValidationBuilder<BankViewModel> builder = new ValidationBuilder<BankViewModel>();

            builder.RuleFor(vm => vm.NameFull).NotEmpty().MinLength(1);
            builder.RuleFor(vm => vm.NameShort).NotEmpty().MinLength(1);
            builder.RuleFor(vm => vm.Inn).NotEmpty().MinLength(12).MaxLength(12);
            builder.RuleFor(vm => vm.Bik).NotEmpty().MinLength(9).MaxLength(9);
            builder.RuleFor(vm => vm.KorAccount).NotEmpty().MinLength(20).MaxLength(20);
            builder.RuleFor(vm => vm.AccounNumber).NotEmpty().MinLength(20).MaxLength(20);
            builder.RuleFor(vm => vm.City).NotEmpty().MinLength(1);

            if (builder.Build(this).IsValid == true)
                _CanAddNewBank = true;
            else
                _CanAddNewBank = false;
            return builder.Build(this);
        }
        public static Bank SelectedBank { get; set; }
        private RelayCommand addNewBank;
        public RelayCommand AddNewBank
        {
            get
            {
                return addNewBank ?? new RelayCommand(obj =>
                {
                    GetValidator();
                    if (_CanAddNewBank)
                    {
                        Window wnd = obj as Window;
                        Controller.CreateBank(NameFull, NameShort, Inn, Bik, KorAccount, AccounNumber, City);
                        wnd.Close();
                        SetNullsOnProperties();
                    }
                    else if (_CanAddNewBank == false)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

        private RelayCommand editBank;
        public RelayCommand EditBank
        {
            get
            {
                return editBank ?? new RelayCommand(obj =>
                {
                    GetValidator();
                    if (_CanAddNewBank)
                    {
                            Window wnd = obj as Window;
                            Controller.EditBank(SelectedBank,NameFull,NameShort,Inn,Bik,KorAccount,AccounNumber,City);
                            wnd.Close();
                        
                      
                    }
                    else if (_CanAddNewBank == false)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                });
            }
        }

        private void SetNullsOnProperties()
        {
            NameFull = null;
            NameShort = null;
            Bik = null;
            Inn = null;
            KorAccount = null;
            AccounNumber = null;
            City = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
