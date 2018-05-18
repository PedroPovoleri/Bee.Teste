using Microsoft.AspNetCore.Mvc;
using Bll.Validation.Interfaces;
using Microsoft.AspNetCore.Http;

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
            try
            {
                var _id = HttpContext.Session.GetString("UserId");

                int id = int.Parse(_id);

                if (_resources.UserHasResourceAuthorization(id, "CRUD"))
                {
                    ViewData["CanEdit"] = true;
                    return View();

                }
                ViewData["CanEdit"] = false;
                return View();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}