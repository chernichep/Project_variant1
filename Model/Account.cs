using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using ReactiveValidation;
using System.ComponentModel;
using ReactiveValidation.Extensions;
using ReactiveValidation.Attributes;
using System.Linq;
using Project.Query;

namespace Project.Model
{
    public class Account 
    {
        public int Id { get; set; }
        public int Bank_Id { get; set; }
        public int Aggrement_Id { get; set; }
        public int Type_Id { get; set; }
        public string AccountNumber { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual Aggrement Aggrement { get; set; }
        public virtual AccountType AccountType { get; set; }

        [NotMapped]
        public Bank AccountBank
        {
            get
            {
                return Controller.GetBankById(Bank_Id);
            }
        }
        [NotMapped]
        public Aggrement AccountAggrement
        {
            get
            {
                return Controller.GetAggrementById(Aggrement_Id);
            }
        }
        [NotMapped]
        public AccountType AccountAccountType
        {
            get
            {
                return Controller.GetAccountTypesById(Type_Id);
            }
        }

    }
}
    