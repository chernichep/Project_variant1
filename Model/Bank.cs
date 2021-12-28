using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Query;
using ReactiveValidation;
using ReactiveValidation.Extensions;

namespace Project.Model
{
    public class Bank
    {
        public int Id { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string Inn { get; set; }
        public string Bik { get; set; }
        public string KorAccount { get; set; }
        public string AccounNumber { get; set; }
        public string City { get; set; }

        public List<Account> Accounts { get; set; }

        [NotMapped]
        public List<Account> AccountTypesAccounts
        {
            get
            {
                return Controller.GetAllAccountsByAccountTypeId(Id);
            }
        }
    }
}
