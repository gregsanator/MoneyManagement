using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.DTO
{
    public class IncomeTypeListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class IncomeTypeForm
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class IncomeTypeSave
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}