using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.DTO
{
    public class ExpenseType
    {
        public class ExpenseTypeListItem
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class ExpenseTypeForm
        {
            public string Name { get; set; }
            public DateTime DateCreated { get; set; }
        }

        public class ExpenseTypeSave
        {
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
            public string Name { get; set; }
            public DateTime DateCreated { get; set; }
        }
    }
}