using MoneyManagement.DTO;
using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.Services
{
    public class UserService
    {
        public List<UserListItem> List() // returns a list of UserListItems(DTO) which contain the property Id and UserSum
        {
            using (var context = new MoneyManagementDbContext())
            {
                List<UserListItem> users = context.Users.Select(a => new UserListItem
                {
                    Id = a.Id,
                    FullName = a.Name + " " + a.Surname
                }).ToList();
                return users;
            }
        }

        public UserForm Details(Guid id) // returns a single UserForm(DTO) obj for a given Id
        {
            using (var context = new MoneyManagementDbContext())
            {
                UserForm users = context.Users.Select(a => new UserForm
                {
                    Name = a.Name,
                    Surname = a.Surname,
                    Age = a.Age
                }).FirstOrDefault();
                return users;
            }
        }

        public bool Save(UserSave model)

        // Same function for delete and save - checking if the newly created User obj has an id or not
        // if it has an id than it means we are modifying an existing record else we are creating a new one
        {
            using (var context = new MoneyManagementDbContext())
            {
                User User = new User
                {
                    Id = model.Id,
                    Age = model.Age,
                    Surname = model.Surname,
                    Name = model.Name
                };

                if (User.Id != Guid.Empty)
                {
                    context.Users.Attach(User);
                    context.Entry(User).Property(a => a.Name).IsModified = true;
                    context.Entry(User).Property(a => a.Surname).IsModified = true;
                    context.Entry(User).Property(a => a.Age).IsModified = true;
                }
                else
                    context.Users.Add(User);
                context.SaveChanges();
                return true;
            }
        }

        // services above are for adminstrators

        public double Balance(UserBalanceFilter filter)
        {
            using (var context = new MoneyManagementDbContext())
            {
                IQueryable<Expense> expenses = context.Expenses.Where(a => a.UserId == filter.UserId);
                IQueryable<Income> incomes = context.Incomes.Where(a => a.UserId == filter.UserId);

                if (filter.Month.HasValue)
                {
                    expenses = expenses.Where(a => a.Month == filter.Month);
                    incomes = incomes.Where(a => a.Month == filter.Month);
                }

                double totalExpenses = expenses.Sum(a => a.ExpenseSum);
                double totalIncomes = incomes.Sum(a => a.IncomeSum);
                return totalIncomes - totalExpenses;
            }
        }
    }
}