using MoneyManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MoneyManagement.Controllers
{
    public class ExpenseController : ApiController
    {
        // GET: Expense
        [HttpGet]
        [Route("api/moneymanagement/expense/list")]
        public IHttpActionResult List(ExpenseMonthFilter filter)
        {
            ExpenseService service = new ExpenseService();
            List<ExpenseListItem> list = service.List(filter);
            return Ok(list);
        }

        [HttpGet]
        [Route("api/moneymanagement/expense/details/{id}")]
        public IHttpActionResult Details(Guid id)
        {
            ExpenseService service = new ExpenseService();
            ExpenseForm details = service.Details(id);
            return Ok(details);
        }

        [HttpPost]
        [Route("api/moneymanagement/expense/save")]
        public IHttpActionResult Save(ExpenseSave model)
        {
            ExpenseService service = new ExpenseService();
            bool success = service.Save(model);
            return Ok(success);
        }

        [HttpDelete]
        [Route("api/moneymanagement/expense/delete/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            ExpenseService service = new ExpenseService();
            bool delete = service.Delete(id);
            return Ok(delete);
        }
    }
}