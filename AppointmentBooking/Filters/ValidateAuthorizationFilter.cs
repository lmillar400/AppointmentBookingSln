using AppointmentBooking.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppointmentBooking.Controllers;

namespace AppointmentBooking.Filters
{
    public class ValidateAuthorizationFilter:ActionFilterAttribute
    {
        public Tasks task { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session.GetInt32("RoleId") == null)
            {
                filterContext.HttpContext.Response.Redirect("/Home/Login?error=2");
            }

            var roleId = filterContext.HttpContext.Session.GetInt32("RoleId");
            AuthorizeEngine engine = new AuthorizeEngine();
            
            bool grantAccess = engine.Authorize(task, Convert.ToInt32(roleId));

            if(!grantAccess)
            {
                var controller = (ControllerBase)filterContext.Controller;
                filterContext.Result = controller.RedirectToAction("UnAuthorized", "Home");
            }
        }
    }
}
