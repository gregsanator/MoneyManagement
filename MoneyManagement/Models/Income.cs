using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoneyManagement.Models
{
    public class Income
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //PK
        public Guid Id { get; set; }


        [ForeignKey("IncomeType")] // FK
        public Guid IncomeTypeId { get; set; }
        public IncomeType IncomeType { get; set; }


        [ForeignKey("User")] // FK
        public Guid UserId { get; set; }
        public User User { get; set; }


        public string Name { get; set; }
        public double IncomeSum { get; set; }
        public DateTime Month { get; set; }
    }
}