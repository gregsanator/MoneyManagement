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
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeType> IncomeTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<AdministratorPermission> AdministratorPermissions { get; set; }
    }
}