using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.DTO
{
    public class UserListItem // List all users 
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }

    public class UserForm // List all users 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }

    public class UserSave // List all users 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }

    public class UserReport // List all users 
    {
        public double TotalExpenses { get; set; }
        public double TotalIncome { get; set; }
    }
}