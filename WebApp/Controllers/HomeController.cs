using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Request;
using Microsoft.AspNetCore.Http;
using Bll.Login.Interface;
using Bll.Validation.Interfaces;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogin _loginBll;
        
        public HomeController(ILogin loginBll)
        {
            _loginBll = loginBll;

        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                ViewData["showLogin"] = true;
            }
            
            return View();
        }

       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}
