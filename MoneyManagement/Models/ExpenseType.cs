using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoneyManagement.Models
{
    public class ExpenseType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //PK
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }


        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}