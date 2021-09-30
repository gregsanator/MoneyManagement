using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyManagement.DTO
{
    public class Administrator
    {
        public class AdministratorListItem
        {
            public Guid Id { get; set; }
            public string Username { get; set; }
            public bool Enabled { get; set; }
        }

        public class AdministratorForm
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public bool Enabled { get; set; }
            public string Username { get; set; }
        }

        public class AdministratorSave
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class AdministratorPermissions
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public bool Enabled { get; set; }
        }

        public class AdministratorPermissionEnable
        {
            public Guid AdministratorId { get; set; }
            public Guid PermissionId { get; set; }
        }

    }
}