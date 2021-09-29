using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MoneyManagement.DTO.ExpenseType;

namespace MoneyManagement.Services
{
    public class ExpenseTypeService
    {
        public List<ExpenseTypeListItem> List(Guid id) // returns all the ExpenseTypes that the user has created 
        {
            using (var context = new MoneyManagementDbContext())
            {
                List<ExpenseTypeListItem> ExpenseTypeList = context.ExpenseTypes.Where(a => a.UserId == id).Select(a => new ExpenseTypeListItem
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList();
                return ExpenseTypeList;
            }
        }

        public ExpenseTypeForm Details(Guid id) // shows the details of the Expense type
        {
            using (var context = new MoneyManagementDbContext())
            {
                ExpenseTypeForm ExpenseType = context.ExpenseTypes.Where(a => a.Id == id).Select(a => new ExpenseTypeForm
                {
                    Name = a.Name,
                    DateCreated = a.DateCreated
                }).FirstOrDefault();
                return ExpenseType;
            }
        }

        public bool Save(ExpenseTypeSave model)
        {
            using (var context = new MoneyManagementDbContext())
            {
                ExpenseType ExpenseType = new ExpenseType
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    DateCreated = model.DateCreated,
                    Name = model.Name
                };

                if (ExpenseType.Id != Guid.Empty)
                {
                    context.ExpenseTypes.Attach(ExpenseType);
                    context.Entry(ExpenseType).Property(a => a.Name).IsModified = true;
                }
                else
                    context.ExpenseTypes.Add(ExpenseType);
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(Guid id)
        {
            using(var context = new MoneyManagementDbContext())
            {
                context.ExpenseTypes.Remove(context.ExpenseTypes.Where(a => a.Id == id).FirstOrDefault());
                context.SaveChanges();
                return true;
            }
        }
    }
}