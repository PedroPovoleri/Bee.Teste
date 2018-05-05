using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll.Login.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.WebModel.Request;

namespace Web.Controllers
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
            return View();
        }

           [HttpPost]
        public IActionResult Login(LoginRequest usr)
        {
            var id = _loginBll.ValidateUser(usr.username, usr.password);

            if (id > 0)
            {
                HttpContext.Session.SetString("UserId", id.ToString());
                return RedirectToAction("Custumers/List", null);
            }

            return View(401);
            
        }
    }
}