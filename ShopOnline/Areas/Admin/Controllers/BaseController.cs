using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext fillcontext)
        {
            if (Session["IDUs"] == null)
            {
                fillcontext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(fillcontext);
        }
        protected void SetAlert(string mes, string type)
        {
            TempData["AlertMessage"] = mes;
            if(type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if(type =="warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if(type== "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
	}
}