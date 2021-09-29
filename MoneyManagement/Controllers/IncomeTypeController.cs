using MoneyManagement.DTO;
using MoneyManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MoneyManagement.Controllers
{
    public class IncomeTypeController : ApiController
    {
        [HttpGet]
        [Route("api/moneymanagement/incometypes/list/{id}")]
        public IHttpActionResult List(Guid id)
        {
            IncomeTypeService service = new IncomeTypeService();
            List<IncomeTypeListItem> list = service.List(id);
            return Ok(list);
        }

        [HttpGet]
        [Route("api/moneymanagement/incometypes/details/{id}")]
        public IHttpActionResult Details(Guid id)
        {
            IncomeTypeService service = new IncomeTypeService();
            IncomeTypeForm incomeType = service.Details(id);
            return Ok(incomeType);
        }

        [HttpPost]
        [Route("api/moneymanagement/incometypes/save")]
        public IHttpActionResult Save(IncomeTypeSave model)
        {
            IncomeTypeService service = new IncomeTypeService();
            bool save = service.Save(model);
            return Ok(save);
        }

        [HttpDelete]
        [Route("api/moneymanagement/incometypes/delete/{id}")]
        public IHttpActionResult Delete(IncomeTypeSave model)
        {
            IncomeTypeService service = new IncomeTypeService();
            bool save = service.Save(model);
            return Ok(save);
        }
    }
}