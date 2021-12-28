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
    class AggrementViewModel : ValidatableObject, INotifyPropertyChanged
    {
        private bool _CanAddNewAggrement = false;

        private static string number, dateopen, dataclose, notes;
        #region AggrementPropertiesRegion
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Номер'")]
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                NotifyPropertyChanged("Number");
            }
        }
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Дата заключения'")]
        public string DateOpen
        {
            get { return dateopen; }
            set
            {
                dateopen = value;
                NotifyPropertyChanged("DateOpen");
            }
        }
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Дата закрытия'")]
        public string DataClose
        {
            get { return dataclose; }
            set
            {
                dataclose = value;
                NotifyPropertyChanged("DataClose");
            }
        }
        [ReactiveValidation.Attributes.DisplayName(DisplayName = "'Заметки'")]
        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                NotifyPropertyChanged("Notes");
            }
        }
        #endregion 

        public AggrementViewModel()
        {
            Validator = GetValidator();
        }
        public IObjectValidator GetValidator()
        {
            ValidationBuilder<AggrementViewModel> builder = new ValidationBuilder<AggrementViewModel>();

            builder.RuleFor(vm => vm.Number).NotEmpty().MinLength(4).MaxLength(10);
            builder.RuleFor(vm => vm.DateOpen).NotEmpty();
            builder.RuleFor(vm => vm.DataClose).NotEmpty().NotEqual(DateOpen).WithLocalizedMessage("Дата закрытия не может быть равна дате заключения договора");
            builder.RuleFor(vm => vm.Notes).NotEmpty().MinLength(1);


            if (builder.Build(this).IsValid == true)
                _CanAddNewAggrement = true;
            else
                _CanAddNewAggrement = false;
            return builder.Build(this);
        }
        private RelayCommand addNewAggrement;
        public RelayCommand AddNewAggrement
        {
            get
            {
                return addNewAggrement ?? new RelayCommand(obj =>
                {
                    GetValidator();
                    if (_CanAddNewAggrement)
                    {
                        Window wnd = obj as Window;
                        Controller.CreateAggrement(Number,DateOpen,DataClose,Notes);
                        wnd.Close();
                        SetNullsOnProperties();
                    }
                    else if (_CanAddNewAggrement == false)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

        private RelayCommand editAggrement;
        public RelayCommand EditAggrement
        {
            get
            {
                return editAggrement ?? new RelayCommand(obj =>
                {
                    GetValidator();
                    if (_CanAddNewAggrement)
                    {
                        Window wnd = obj as Window;
                        Controller.EditAggrement(SelectedAggrement,Number,dateopen,dataclose,notes);
                        wnd.Close();


                    }
                    else if (_CanAddNewAggrement == false)
                    {
                        MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                });
            }
        }
        public static Aggrement SelectedAggrement { get; set; }
        private void SetNullsOnProperties()
        {
            Number = null;
            DateOpen = null;
            DataClose = null;
            Notes = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
