using Bll.Validation.Implemetiation;
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
        public string resourceName;

        public ResourcesAccessFilter()
        {

        }

        public ResourcesAccessFilter(string _resourceName, IResources resources)
        {
            _resources = resources;
            _resourceName = resourceName;
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                
                if ((string.IsNullOrWhiteSpace(resourceName) == false) && (resourceName.Equals("Public") == false))
                {
              
                    bool hasAuthorization = _resources.UserHasResourceAuthorization(1, resourceName);

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

