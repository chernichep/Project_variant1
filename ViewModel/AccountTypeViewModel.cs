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
    public class AccountTypeViewModel : ValidatableObject, INotifyPropertyChanged
    {
        public bool _CanAddNewAccounType = false;

        public AccountTypeViewModel()
        {
            Validator = GetValidator();
        }

        public IObjectValidator GetValidator()
        {
            ValidationBuilder<AccountTypeViewModel> builder = new ValidationBuilder<AccountTypeViewModel>();

            builder.RuleFor(vm => vm.Type).NotEmpty().MinLength(1);

            if (builder.Build(this).IsValid == true)
                _CanAddNewAccounType = true;
            else
                _CanAddNewAccounType = false; 
            return builder.Build(this);
        }


        private static string type;
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Тип'")]
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }
        private RelayCommand addNewAccountType;
        public static AccountType SelectedType { get; set; }
        public RelayCommand AddNewAccountType
        {
            get
            {
                return addNewAccountType ?? new RelayCommand(obj =>
                {
                    GetValidator();
                    if (_CanAddNewAccounType)
                    {
                        Window wnd = obj as Window;
                        Controller.CreateAccountType(Type);
                        wnd.Close();
                        SetNullsOnProperties();
                    }
                    else if (_CanAddNewAccounType == false)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }
        private RelayCommand editType;
        public RelayCommand EditType
        {
            get
            {
                return editType ?? new RelayCommand(obj =>
                {
                    GetValidator();
                    if (_CanAddNewAccounType)
                    {
                        Window wnd = obj as Window;
                        Controller.EditAccountType(SelectedType, Type);
                        wnd.Close();


                    }
                    else if (_CanAddNewAccounType == false)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                });
            }
        }
        private void SetNullsOnProperties()
        {
            Type = null;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
