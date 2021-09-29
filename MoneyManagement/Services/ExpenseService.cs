using MoneyManagement.DTO;
using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement
{
    public class ExpenseService
    {
        public List<ExpenseListItem> List(ExpenseMonthFilter filter) //Returns all expenses recorded if admin else returns only user's expenses if user
        {
            using(var context = new MoneyManagementDbContext())
            {
                IQueryable<Expense> expenses = context.Expenses;

                if (filter.Month.HasValue)
                    expenses = expenses.Where(a => a.Month == filter.Month);

                List <ExpenseListItem> expenseList = expenses.Select(a => new ExpenseListItem
                {
                    Id = a.Id,
                    ExpenseSum = a.ExpenseSum
                }).ToList();

                return expenseList;
            }
        }

        public ExpenseForm Details(Guid id) // returns a single ExpenseForm(DTO) obj for a given Id
        {
            using (var context = new MoneyManagementDbContext())
            {
                ExpenseForm expenses = context.Expenses.Select(a => new ExpenseForm
                {
                    ExpenseSum = a.ExpenseSum,
                    ExpenseTypeName = a.ExpenseType.Name,
                    Name = a.Name,
                    Month = a.Month
                }).FirstOrDefault();
                return expenses;
            }
        }

        public bool Save(ExpenseSave model) 
            
            // Same function for delete and save - checking if the newly created expense obj has an id or not
            // if it has an id than it means we are modifying an existing record else we are creating a new one
        {
            using (var context = new MoneyManagementDbContext())
            {
                Expense expense = new Expense
                {
                    Id = model.Id,
                    Name = model.Name,
                    Month = model.Month,
                    ExpenseTypeId = model.ExpenseTypeId,
                    ExpenseSum = model.ExpenseSum,
                    UserId = model.UserId
                };

                if (expense.Id != Guid.Empty)
                {
                    context.Expenses.Attach(expense);
                    context.Entry(expense).Property(a => a.Name).IsModified = true;
                    context.Entry(expense).Property(a => a.ExpenseTypeId).IsModified = true;
                    context.Entry(expense).Property(a => a.Month).IsModified = true;
                    context.Entry(expense).Property(a => a.ExpenseSum).IsModified = true;
                }
                else
                {
                    context.Expenses.Add(expense);
                }
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MoneyManagementDbContext())
            {
                context.Expenses.Remove(context.Expenses.Where(a => a.Id == id).FirstOrDefault());
                return true;
            }
        }
    }
}