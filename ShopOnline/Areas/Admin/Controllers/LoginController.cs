using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var DAO = new AccountModel();
                var IDUser = DAO.GetIDUser(model.Username);
                var Res = DAO.Login(model.Username, model.Password);
                if(Res == 1)
                {
                    Session["User"] = model.Username.ToString();
                    Session["IDUs"] = IDUser.IDAcc.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else if(Res == 0)
                {
                    ModelState.AddModelError("error", "*Tài khoản không tồn tại");
                }
                else if (Res == -1)
                {
                    ModelState.AddModelError("error", "*Mật khẩu không đúng.");
                }
            }
            else
            {
                ModelState.AddModelError("error", "*Đăng nhập không thành công.Lỗi #101");
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("index", "Login");
        }
	}
}