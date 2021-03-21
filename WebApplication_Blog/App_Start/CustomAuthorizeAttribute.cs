using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_Blog.Models;

namespace WebApplication_Blog.App_Start
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual Login CurrentUser
        {
            get { return HttpContext.Current.Session["User"] as Login; }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return CurrentUser != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            if (CurrentUser == null)
            {
                routeData = new RedirectToRouteResult
                    (new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        controller = "Login",
                        action = "Login",
                    }
                    ));
            }
            else
            {
                routeData = new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                 (new
                 {
                     controller = "Blog",
                     action = "Index"
                 }
                 ));
            }

            filterContext.Result = routeData;

            filterContext.Result = routeData;
        }
    }
}