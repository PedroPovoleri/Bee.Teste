using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bll.Login.Interface;
using WebApp.Models.Request;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _loginBll;

        public LoginController(ILogin loginBll)
        {
            _loginBll = loginBll;
        }

        public IActionResult Index()
        {
            return PartialView("_LoginPage");
        }

        [HttpPost]
        public IActionResult LoginValidate(LoginRequest usr)
        {
            var id = _loginBll.ValidateUser(usr.username, usr.password);

            if (id > 0)
            {
                HttpContext.Session.SetString("UserId", id.ToString());
                return RedirectToAction("Index", "DataGrid");
            }
            return View(401);
        }
    }
}