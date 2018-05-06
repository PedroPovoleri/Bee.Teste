using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bll.Validation.Interfaces;

namespace WebApp.Controllers
{
    public class DataGridController : Controller
    {
        private readonly IResources _resources;

        public DataGridController(IResources resources)
        {
            _resources = resources;
        }

        public IActionResult Index()
        {
            ViewData["CanEdit"] = _resources.UserHasResourceAuthorization(1,"CRUD");
            return View();
        }
    }
}