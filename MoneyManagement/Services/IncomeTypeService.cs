using MoneyManagement.DTO;
using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.Services
{
    public class IncomeTypeService
    {
        public List<IncomeTypeListItem> List(Guid id) // returns all the incomeTypes that the user has created 
        {
            using (var context = new MoneyManagementDbContext())
            {
                List<IncomeTypeListItem> incomeTypeList = context.IncomeTypes.Where(a => a.UserId == id).Select(a => new IncomeTypeListItem
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList();
                return incomeTypeList;
            }
        }

        public IncomeTypeForm Details(Guid id) // shows the details of the income type
        {
            using (var context = new MoneyManagementDbContext())
            {
                IncomeTypeForm incomeType = context.IncomeTypes.Where(a => a.Id == id).Select(a => new IncomeTypeForm
                {
                    Name = a.Name,
                    DateCreated = a.DateCreated
                }).FirstOrDefault();
                return incomeType;
            }
        }

        public bool Save(IncomeTypeSave model)
        {
            using(var context = new MoneyManagementDbContext())
            {
                IncomeType incomeType = new IncomeType
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    DateCreated = model.DateCreated,
                    Name = model.Name
                };

                if (incomeType.Id != Guid.Empty)
                {
                    context.IncomeTypes.Attach(incomeType);
                    context.Entry(incomeType).Property(a => a.Name).IsModified = true;
                }
                else
                    context.IncomeTypes.Add(incomeType);
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MoneyManagementDbContext())
            {
                context.IncomeTypes.Remove(context.IncomeTypes.Where(a => a.Id == id).FirstOrDefault());
                context.SaveChanges();
                return true;
            }
        }
    }
}