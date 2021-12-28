using Project.Model;
using Project.Data;
using System.Linq;
using System;
using System.Windows;
using System.Collections.Generic;

namespace Project.Query
{
    public static class Controller
    {

        //Просмотр
        public static List<Account> GetAccounts()
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                var resultList = database.Accounts.ToList();
                return resultList;
            }
        }

        public static List<AccountType> GetAccountTypes()
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                var resultList = database.AccountTypes.ToList();
                return resultList;
            }
        }

        public static List<Aggrement> GetAggrements()
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                var resultList = database.Aggrements.ToList();
                return resultList;
            }
        }

        public static List<Bank> GetBanks()
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                var resultList = database.Banks.ToList();
                return resultList;
            }
        }

        //Создания
        public static void CreateAccountType(string type)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                if (!database.AccountTypes.Any(n => n.Type == type))
                {
                    AccountType accType = new AccountType { Type = type };
                    database.AccountTypes.Add(accType);
                    database.SaveChanges();
                    SuccessfulCreated(true);
                } else { SuccessfulCreated(false); }
            }
        }
        public static void CreateAggrement(string number, string dataopen, string dataclose,string notes)
        {
            if(CheckAggrement(number,dataopen,dataclose))
            {
                using (ApplicationContext database = new ApplicationContext())
                {
                    if (!database.Aggrements.Any(a => a.Number == number))
                    {
                        Aggrement agg = new Aggrement
                        {
                            Number = number,
                            DateOpen = dataopen,
                            DataClose = dataclose,
                            Notes = notes
                        };
                        database.Aggrements.Add(agg);
                        database.SaveChanges();
                        SuccessfulCreated(true);
                    } else { SuccessfulCreated(false); }
                }
            }
        }

        public static void CreateBank(string namefull,string nameshort,string inn, string bik,string koraccount,string accountnumber,string city)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                if(!database.Banks.Any(b=> b.Inn == inn))
                {
                    Bank bank = new Bank 
                    { 
                        NameFull = namefull, 
                        NameShort = nameshort, 
                        Inn = inn, Bik = bik, 
                        KorAccount = koraccount, 
                        AccounNumber = accountnumber, 
                        City = city
                    };
                    database.Banks.Add(bank);
                    database.SaveChanges();
                    SuccessfulCreated(true);
                } else { SuccessfulCreated(false); }
            }
        }

        //Поиск по ID
        public static Bank GetBankById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Bank pos = db.Banks.FirstOrDefault(a => a.Id == id);
                return pos;
            }
        }
        public static Aggrement GetAggrementById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Aggrement pos = db.Aggrements.FirstOrDefault(a => a.Id == id);
                return pos;
            }
        }
        public static AccountType GetAccountTypesById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                AccountType pos = db.AccountTypes.FirstOrDefault(a => a.Id == id);
                return pos;
            }
        }

        public static List<Account> GetAllAccountsByAccountTypeId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Account> accounts = (from Account in GetAccounts() where Account.Type_Id == id select Account).ToList();
                return accounts;
            }
        }
        public static List<Account> GetAllAccountsByAggrementId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Account> accounts = (from Account in GetAccounts() where Account.Aggrement_Id == id select Account).ToList();
                return accounts;
            }
        }
        public static List<Account> GetAllAccountsByBankId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Account> accounts = (from Account in GetAccounts() where Account.Bank_Id == id select Account).ToList();
                return accounts;
            }
        }
        public static void CreateAccount(string accountnumber, Bank bank, Aggrement aggrement, AccountType accounttype)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                if (!database.Accounts.Any(a => a.AccountNumber == accountnumber))
                {
                    Account acc = new Account
                    {
                        Bank_Id = bank.Id,
                        Aggrement_Id = aggrement.Id,
                        Type_Id = accounttype.Id,
                        AccountNumber = accountnumber
                    };
                    database.Accounts.Add(acc);
                    database.SaveChanges();
                    SuccessfulCreated(true);
                } else { SuccessfulCreated(false); }
            }
        }
        //Уведомления
        public static void SuccessfulCreated(bool SuccOfNo)
        {
            if (SuccOfNo)
                MessageBox.Show("Запись успешно создана!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Данная запись уже создана!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        //Проверки
        public static bool CheckAggrement(string number, string dataopen, string dataclose)
        {
            if (Convert.ToDateTime(dataclose) < Convert.ToDateTime(dataopen))
            {
                MessageBox.Show("Дата закрытия договора не может быть раньше даты заключения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            } else return true;
        }
        public static void SuccEditRow(bool SuccOrNo, string ObjectName, string NewObjectName)
        {
            if (SuccOrNo)
            {
                MessageBox.Show($"Запись {ObjectName} была изменена на {NewObjectName}.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show($"Запись {ObjectName} не была изменена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public static void SuccessfulDelete(bool SuccOfNo)
        {
            if (SuccOfNo)
                MessageBox.Show("Запись успешно удалена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Данная запись не найдена в базе данных!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Удаления
        public static void DeleteAccount(Account account)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                if(database.Accounts.Any(a=> a == account))
                {
                    var result = MessageBox.Show("Вы уверены что хотите удалить запись?","Подтверждение",MessageBoxButton.YesNo,MessageBoxImage.Question);
                    if(result == MessageBoxResult.Yes)
                    {
                        database.Accounts.Remove(account);
                        database.SaveChanges();
                        SuccessfulDelete(true);
                    }
                } else { SuccessfulDelete(false); }
            }
        }

        public static void DeleteAccountType(AccountType accountType)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                if (database.AccountTypes.Any(a => a == accountType))
                {
                    var result = MessageBox.Show("Вы уверены что хотите удалить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        database.AccountTypes.Remove(accountType);
                        database.SaveChanges();
                        SuccessfulDelete(true);
                    }
                }
                else { SuccessfulDelete(false); }
            }
        }

        public static void DeleteBank(Bank bank)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                if (database.Banks.Any(b => b == bank))
                {
                    var result = MessageBox.Show("Вы уверены что хотите удалить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        database.Banks.Remove(bank);
                        database.SaveChanges();
                        SuccessfulDelete(true);
                    }
                }
                else { SuccessfulDelete(false); }
            }
        }

        public static void DeleteAggrement(Aggrement aggrement)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                if (database.Aggrements.Any(a => a == aggrement))
                {
                    var result = MessageBox.Show("Вы уверены что хотите удалить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        database.Aggrements.Remove(aggrement);
                        database.SaveChanges();
                        SuccessfulDelete(true);
                    }
                }
                else { SuccessfulDelete(false); }
            }
        }

        //Редактирования
        public static void EditAccountType(AccountType oldaccounttype,string newType)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                AccountType acc = database.AccountTypes.FirstOrDefault(a=> a.Id == oldaccounttype.Id);
                acc.Type = newType;
                database.SaveChanges();
                SuccEditRow(true,oldaccounttype.Type,newType);
            }
        }

        public static void EditAccount(Account oldaccount,string newAccountNumber, Bank newBank,Aggrement newAggrement, AccountType newAccountType)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                if(database.Accounts.Any(a => a.AccountNumber == oldaccount.AccountNumber))
                {
                    Account acc = database.Accounts.FirstOrDefault(a => a.Id == oldaccount.Id);
                    acc.Bank_Id = newBank.Id;
                    acc.Aggrement_Id = newAggrement.Id;
                    acc.Type_Id = newAccountType.Id;
                    acc.AccountNumber = newAccountNumber;
                    database.SaveChanges();
                    SuccEditRow(true, oldaccount.AccountNumber, newAccountNumber);
                } else { SuccessfulDelete(false); }
            }
        }

        public static void EditAggrement(Aggrement oldaggrement, string newAggrementNumber, string newAggrementDateOpen, string newAggrementDataClose,string newAggrementNotes)
        {
            using (ApplicationContext database = new ApplicationContext())
            {

                    if (database.Aggrements.Any(a => a.Id == oldaggrement.Id))
                    {
                        Aggrement agg = database.Aggrements.FirstOrDefault(a => a.Id == oldaggrement.Id);
                        agg.Number = newAggrementNumber;
                    agg.DateOpen = newAggrementDateOpen;
                    agg.DataClose = newAggrementDataClose;
                        agg.Notes = newAggrementNotes;

                        database.SaveChanges();
                        SuccEditRow(true, oldaggrement.Number, newAggrementNumber);
                    }
                
            }
        }

        public static void EditBank(Bank oldbank, string newNameFull, string newNameShort, string newInn, string newBik, string newKorAccount, string newAccountNumber, string newCity)
        {
            using (ApplicationContext database = new ApplicationContext())
            {
                Bank bank = database.Banks.FirstOrDefault(b => b.Id == oldbank.Id);
                bank.NameFull = newNameFull;
                bank.NameShort = newNameShort;
                bank.Inn = newInn;
                bank.Bik = newBik;
                bank.KorAccount = newKorAccount;
                bank.AccounNumber = newAccountNumber;
                bank.City = newCity;
                database.SaveChanges();
                SuccEditRow(true, oldbank.Inn, newInn);
            }
        }
    }
}
