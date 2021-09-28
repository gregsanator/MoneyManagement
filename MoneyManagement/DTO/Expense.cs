using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.DTO
{
    public class ExpenseListItem
    {
        public Guid Id { get; set; }
        public double ExpenseSum { get; set; }
    }

    public class ExpenseForm
    {
        public string Name { get; set; }
        public string ExpenseTypeName { get; set; }
        public double ExpenseSum { get; set; }
        public DateTime Month { get; set; }
    }

    public class ExpenseSave
    {
        public Guid Id { get; set; }
        public Guid ExpenseTypeId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ExpenseTypeName { get; set; }
        public double ExpenseSum { get; set; }
        public DateTime Month { get; set; }
    }
}