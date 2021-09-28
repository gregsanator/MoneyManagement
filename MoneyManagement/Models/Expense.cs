using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoneyManagement.Models
{
    public class Expense
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //PK
        public Guid Id { get; set; }


        [ForeignKey("ExpenseType")] // FK
        public Guid ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }


        [ForeignKey("User")] // FK
        public Guid UserId { get; set; }
        public User User { get; set; }


        public string Name { get; set; }
        public double ExpenseSum { get; set; }
        public DateTime Month { get; set; }

    }


}