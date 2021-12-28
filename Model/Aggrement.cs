using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Query;
using ReactiveValidation;

namespace Project.Model
{
    public class Aggrement
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string DateOpen { get; set; }
        public string DataClose { get; set; }
        public string Notes { get; set; }

        
        public virtual List<Account> Accounts { get; set; }

        [NotMapped]
        public List<Account> AccountTypesAccounts
        {
            get
            {
                return Controller.GetAllAccountsByAggrementId(Id);
            }
        }
    }
}
