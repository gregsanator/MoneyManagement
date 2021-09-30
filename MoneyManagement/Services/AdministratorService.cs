using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MoneyManagement.DTO.Administrator;

namespace MoneyManagement.Services
{
    public class AdministratorService
    {
        public List<AdministratorListItem> List()
        {
            using (var context = new MoneyManagementDbContext())
            {
                List<AdministratorListItem> administratorList = context.Administrators.Select(a => new AdministratorListItem
                {
                    Id = a.Id,
                    Username = a.Username,
                    Enabled = a.Enabled
                }).ToList();
                return administratorList;
            }
        }

        public AdministratorForm Details(Guid id)
        {
            using (var context = new MoneyManagementDbContext())
            {
                AdministratorForm administrator = context.Administrators.Select(a => new AdministratorForm
                {
                    Username = a.Username,
                    Name = a.Name,
                    Surname = a.Surname,
                    Enabled = a.Enabled
                }).FirstOrDefault();
                return administrator;
            }
        }

        public bool Save(AdministratorSave model)
        {
            using (var context = new MoneyManagementDbContext())
            {
                Administrator admin = new Administrator
                {
                    Id = model.Id,
                    Username = model.Username,
                    Name = model.Name,
                    Surname = model.Surname,
                    Password = model.Password
                };

                if (admin.Id != Guid.Empty)
                {
                    context.Administrators.Attach(admin);
                    context.Entry(admin).Property(a => a.Username).IsModified = true;
                    context.Entry(admin).Property(a => a.Name).IsModified = true;
                    context.Entry(admin).Property(a => a.Surname).IsModified = true;
                    context.Entry(admin).Property(a => a.Password).IsModified = true;
                }

                else
                    context.Administrators.Add(admin);

                context.SaveChanges();
                return true;
            }
        }

        public bool Enable(Guid id) //enable or disable admin functionality
        {
            using (var context = new MoneyManagementDbContext())
            {
                Administrator admin = context.Administrators.Where(a => a.Id == id).FirstOrDefault();
                if (admin == null)
                    return false;

                else
                    admin.Enabled = !admin.Enabled;

                context.SaveChanges();
                return true;
            }
        }

        public List<AdministratorPermissions> Permissions(Guid id) //show me all permissions inside permission table 
            //and tell me what are the permissions that this admin with the passed id already has
        {
            using (var context = new MoneyManagementDbContext())
            {
                List<AdministratorPermissions> administratorPermissions = (from p in context.Permissions
                                                       join ap in context.AdministratorPermissions.Where(a => a.AdministratorId == id)
                                                       on p.Id equals ap.PermissionId into joinedpap
                                                       from pap in joinedpap.DefaultIfEmpty()
                                                       select new AdministratorPermissions
                                                       {
                                                           Id = p.Id,
                                                           Name = p.Name,
                                                           Enabled = pap != null
                                                       }).ToList();
                return administratorPermissions;
            }
        }

        public bool EnablePermission(AdministratorPermissionEnable model)// adding or deleting AdministratorPermission from cross table
        {
            using (var context = new MoneyManagementDbContext())
            {
                AdministratorPermission permission = context.AdministratorPermissions.Where
                    (a => a.AdministratorId == model.AdministratorId && a.PermissionId == model.PermissionId).FirstOrDefault();
                if (permission != null)
                    context.AdministratorPermissions.Remove(permission);
                else
                    context.AdministratorPermissions.Add(permission);
                context.SaveChanges();
                return true;
            }
        }
    }
}