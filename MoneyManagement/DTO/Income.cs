using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.DTO
{
    public class IncomeListItem
    {
        public Guid Id { get; set; }
        public double IncomeSum { get; set; }
    }

    public class IncomeForm
    {
        public string Name { get; set; }
        public string IncomeTypeName { get; set; }
        public double IncomeSum { get; set; }
        public DateTime Month { get; set; }
    }

    public class IncomeSave
    {
        public Guid Id { get; set; }
        public Guid IncomeTypeId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public double IncomeSum { get; set; }
        public DateTime Month { get; set; }
    }
}