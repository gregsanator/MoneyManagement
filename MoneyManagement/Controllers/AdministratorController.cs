using MoneyManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static MoneyManagement.DTO.Administrator;

namespace MoneyManagement.Controllers
{
    public class AdministratorController : ApiController
    {
        [HttpGet]
        [Route("api/moneymanagement/administrator/list")]
        public IHttpActionResult List()
        {
            AdministratorService service = new AdministratorService();
            List<AdministratorListItem> list = service.List();
            return Ok(list);
        }

        [HttpGet]
        [Route("api/moneymanagement/administrator/details/{id}")]
        public IHttpActionResult Details(Guid id)
        {
            AdministratorService service = new AdministratorService();
            AdministratorForm details = service.Details(id);
            return Ok(details);
        }

        [HttpPost]
        [Route("api/moneymanagement/administrator/save")]
        public IHttpActionResult Save(AdministratorSave model)
        {
            AdministratorService service = new AdministratorService();
            bool success = service.Save(model);
            return Ok(success);
        }

        [HttpGet]
        [Route("api/moneymanagement/administrator/enable/{id}")]
        public IHttpActionResult Enabled(Guid id)
        {
            AdministratorService service = new AdministratorService();
            bool success = service.Enable(id);
            return Ok(success);
        }

        [HttpGet]
        [Route("api/moneymanagement/administrator/permissions/{id}")]
        public IHttpActionResult Permissions(Guid id)
        {
            AdministratorService service = new AdministratorService();
            List<AdministratorPermissions> permissions = service.Permissions(id);
            return Ok(permissions);
        }

        [HttpPost]
        [Route("api/moneymanagement/administrator/enablepermission")]
        public IHttpActionResult EnablePermission(AdministratorPermissionEnable model)
        {
            AdministratorService service = new AdministratorService();
            bool success = service.EnablePermission(model);
            return Ok(success);
        }
    }
}