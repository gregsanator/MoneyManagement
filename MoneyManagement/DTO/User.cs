using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.DTO
{
    public class UserListItem 
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }

    public class UserForm 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }

    public class UserSave 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }

    public class UserReport
    {
        public double TotalExpenses { get; set; }
        public double TotalIncome { get; set; }
    }

    public class UserBalanceFilter 
    {
        public Guid UserId { get; set; }
        public DateTime? Month { get; set; }
    }

    public class UserEnable
    {
        public Guid Id { get; set; }
        public bool Enabled { get; set; }
    }
}