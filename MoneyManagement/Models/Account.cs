using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoneyManagement.Models
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // PK
        public Guid Id { get; set; }


        [ForeignKey("Income")]
        public Guid IncomeId { get; set; }
        public Income Income { get; set; }

        [ForeignKey("Expense")]
        public Guid ExpenseId { get; set; }
        public Expense Expense { get; set; }
    }
}