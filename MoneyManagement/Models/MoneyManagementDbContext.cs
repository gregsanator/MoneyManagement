using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoneyManagement.Models
{
    public class MoneyManagementDbContext : DbContext
    {
        public MoneyManagementDbContext() : base("name=MoneyManagement")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<IncomeType> IncomeType { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<ExpenseType> ExpenseType { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
    }
}