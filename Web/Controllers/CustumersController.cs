using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bll.Customers.Interfaces;

namespace Web.Controllers
{
    public class CustumersController : Controller
    {
        private readonly ICustomers _customers;

        public CustumersController(ICustomers customers)
        {
            _customers = customers;
        }

        public JsonResult Index()
        {
            JsonResult json = new JsonResult(_customers.GetCustomers());
            return Json(json);
        }

        public IActionResult List()
        {
            return PartialView("_ListCustumers");
        }
    }
}