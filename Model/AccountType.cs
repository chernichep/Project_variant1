using Project.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Model
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Type { get; set; }

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
