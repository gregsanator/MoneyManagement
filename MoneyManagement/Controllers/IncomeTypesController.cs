using MoneyManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static MoneyManagement.DTO.ExpenseType;

namespace MoneyManagement.Controllers
{
    public class ExpenseTypesController : ApiController
    {
        [HttpGet]
        [Route("api/moneymanagement/expensetypes/list/{id}")]
        public IHttpActionResult List(Guid id)
        {
            ExpenseTypeService service = new ExpenseTypeService();
            List<ExpenseTypeListItem> list = service.List(id);
            return Ok(list);
        }

        [HttpGet]
        [Route("api/moneymanagement/expensetypes/details/{id}")]
        public IHttpActionResult Details(Guid id)
        {
            ExpenseTypeService service = new ExpenseTypeService();
            ExpenseTypeForm ExpenseType = service.Details(id);
            return Ok(ExpenseType);
        }

        [HttpPost]
        [Route("api/moneymanagement/expensetypes/save")]
        public IHttpActionResult Save(ExpenseTypeSave model)
        {
            ExpenseTypeService service = new ExpenseTypeService();
            bool save = service.Save(model);
            return Ok(save);
        }

        [HttpDelete]
        [Route("api/moneymanagement/expensetypes/delete/{id}")]
        public IHttpActionResult Delete(ExpenseTypeSave model)
        {
            ExpenseTypeService service = new ExpenseTypeService();
            bool save = service.Save(model);
            return Ok(save);
        }
    }
}