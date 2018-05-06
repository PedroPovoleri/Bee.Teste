using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bll.Customers.Interfaces;
using Model.POCO;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("WebApiCustumerController")]
    public class WebApiCustumerController : Controller
    {
        private readonly ICustomers _customers;

        public WebApiCustumerController(ICustomers customers)
        {
            _customers = customers;
        }

        [HttpGet]
        [Route("GetCustumers")]
        public object GetCustumers(DataSourceLoadOptions loadOptions)
        {
            if (loadOptions.Skip == 0)
            {
                var lst = _customers.GetPaged(loadOptions.Take, 1);
                lst.AddRange(_customers.GetPaged(loadOptions.Take, loadOptions.Take));
                return DataSourceLoader.Load(lst, loadOptions);
            }
            return DataSourceLoader.Load(_customers.GetPaged(loadOptions.Skip, loadOptions.Take), loadOptions);

        }

        [HttpPost]
        [Route("InsertCustumer")]
        public IActionResult InsertCustumer(string values) {
            var newCustumer = new Customers();
            JsonConvert.PopulateObject(values, newCustumer);

            _customers.AddCustumers(newCustumer);
            
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCustumer")]
        public void UpdateCustumer(int key, string values)
        {
            var custumer = _customers.GetCustomersById(key);
            JsonConvert.PopulateObject(values, custumer);
            
            _customers.UpdateCustomers(custumer);

        }

        [HttpDelete]
        [Route("DeleteCustumer")]
        public void DeleteCustumer(int key)
        {
            var custumer = _customers.GetCustomersById(key);
            _customers.RemoveCustumers(custumer);
        }

        [HttpGet]
        [Route("CustumerDetails")]
        public JsonResult CustumerDetails(long customersId)
        {
            JsonResult json = new JsonResult(_customers.GetCustomersById(customersId));
            json.ContentType = "application/json";
            json.StatusCode = 200;

            return Json(json);
        }
        [HttpGet]
        [Route("CustomersLookup")]
        public object CustomersLookup(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var lookup = from i in _customers.GetCustomers()
                             let text = i.name + " (" + i.address + ")"
                             orderby i.name
                             select new
                             {
                                 Value = i.id,
                                 Text = text
                             };

                return DataSourceLoader.Load(lookup, loadOptions);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}