using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoneyManagement.Models
{
    public class AdministratorPermission
    {
        public Guid Id { get; set; }

        [ForeignKey("Administrator")]

        public Guid AdministratorId { get; set; }
        public Administrator Administrator { get; set; }


        [ForeignKey("Permission")]
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}