using MoneyManagement.DTO;
using MoneyManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MoneyManagement.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/moneymanagement/user/list")]
        public IHttpActionResult List()
        {
            UserService service = new UserService();
            List<UserListItem> list = service.List();
            return Ok(list);
        }

        [HttpGet]
        [Route("api/moneymanagement/user/details/{id}")]
        public IHttpActionResult Details(Guid id)
        {
            UserService service = new UserService();
            UserForm details = service.Details(id);
            return Ok(details);
        }

        [HttpPost]
        [Route("api/moneymanagement/user/save")]
        public IHttpActionResult Save(UserSave model)
        {
            UserService service = new UserService();
            bool success = service.Save(model);
            return Ok(success);
        }

        [HttpPost]
        [Route("api/moneymanagement/user/balance")]
        public IHttpActionResult Balance(UserBalanceFilter filter)
        {
            UserService service = new UserService();
            double balance = service.Balance(filter);
            return Ok(balance);
        }
    }
}