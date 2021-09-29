using MoneyManagement.DTO;
using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.Services
{
    public class IncomeService
    {
        public List<IncomeListItem> List(IncomeMonthFilter filter) // returns a list of IncomeListItems(DTO) which contain the property Id and incomeSum
        {
            using (var context = new MoneyManagementDbContext())
            {
                IQueryable<Income> incomes = context.Income;

                if (context.Users.Where(a => a.Id == filter.UserOrAdminId).Any()) // if there is a user with this id
                    incomes = incomes.Where(a => a.Id == filter.UserOrAdminId); // filter all the incomes with a given id

                if (filter.Month.HasValue) // if we have passed a month value
                    incomes = incomes.Where(a => a.Month == filter.Month); // filter the incomes by month

                List<IncomeListItem> incomeList = incomes.Select(a => new IncomeListItem
                {
                    Id = a.Id,
                    IncomeSum = a.IncomeSum
                }).ToList();

                return incomeList;
            }
        }

        public IncomeForm Details(Guid id) // returns a single IncomeForm(DTO) obj for a given Id
        {
            using (var context = new MoneyManagementDbContext())
            {
                IncomeForm incomes = context.Income.Select(a => new IncomeForm
                {
                    IncomeSum = a.IncomeSum,
                    IncomeTypeName = a.IncomeType.Name,
                    Name = a.Name,
                    Month = a.Month
                }).FirstOrDefault();
                return incomes;
            }
        }

        public bool Save(IncomeSave model)

        // Same function for delete and save - checking if the newly created income obj has an id or not
        // if it has an id than it means we are modifying an existing record else we are creating a new one
        {
            using (var context = new MoneyManagementDbContext())
            {
                Income income = new Income
                {
                    Id = model.Id,
                    Name = model.Name,
                    Month = model.Month,
                    IncomeTypeId = model.IncomeTypeId,
                    IncomeSum = model.IncomeSum,
                    UserId = model.UserId
                };

                if (income.Id != Guid.Empty)
                {
                    context.Income.Attach(income);
                    context.Entry(income).Property(a => a.Name).IsModified = true;
                    context.Entry(income).Property(a => a.IncomeTypeId).IsModified = true;
                    context.Entry(income).Property(a => a.Month).IsModified = true;
                    context.Entry(income).Property(a => a.IncomeSum).IsModified = true;
                }
                else
                    context.Income.Add(income);
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MoneyManagementDbContext())
            {
                context.Income.Remove(context.Income.Where(a => a.Id == id).FirstOrDefault());
                return true;
            }
        }
    }
}