using MoneyManagement.DTO;
using MoneyManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MoneyManagement.Controllers
{
    public class IncomeController : ApiController
    {
        [HttpGet]
        [Route("api/moneymanagement/income/list")]
        public IHttpActionResult List(IncomeMonthFilter filter)
        {
            IncomeService service = new IncomeService();
            List<IncomeListItem> list = service.List(filter);
            return Ok(list);
        }

        [HttpGet]
        [Route("api/moneymanagement/income/details/{id}")]
        public IHttpActionResult Details(Guid id)
        {
            IncomeService service = new IncomeService();
            IncomeForm details = service.Details(id);
            return Ok(details);
        }

        [HttpPost]
        [Route("api/moneymanagement/income/save")]
        public IHttpActionResult Save(IncomeSave model)
        {
            IncomeService service = new IncomeService();
            bool success = service.Save(model);
            return Ok(success);
        }

        [HttpDelete]
        [Route("api/moneymanagement/income/delete/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            IncomeService service = new IncomeService();
            bool delete = service.Delete(id);
            return Ok(delete);
        }
    }
}