using Bll.Validation.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Filters
{
    public class ResourcesAccessFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly IResources _resources;
        public string _resourceName;

        public ResourcesAccessFilter()
        {

        }

        public ResourcesAccessFilter(string resourceName, IResources resources)
        {
            resources = _resources;
            _resourceName = resourceName;
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if ((string.IsNullOrWhiteSpace(_resourceName) == false) && (_resourceName.Equals("Public") == false))
                {
                    long userId = 0;//(long)filterContext.HttpContext.Session["userId"];

                    if (_resources.UserNotLogged(userId) == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/login");
                    }

                    if (_resourceName.Equals("Protected"))
                    {
                        return;
                    }
                    if (_resourceName.Equals("PublicoLogado") && _resources.UserNotLogged(userId) == true)
                    {
                        return;
                    }
                    bool hasAuthorization = _resources.UserHasResourceAuthorization(userId, _resourceName);

                    if (hasAuthorization == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/403");
                    }
                }

            }
            catch (Exception)
            {
                filterContext.HttpContext.Response.Redirect("~/login");
            }
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
        }


    }
}

