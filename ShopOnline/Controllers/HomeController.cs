using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class HomeController : Controller
    {
        public const string CastSession = "CastSession";
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.slide = new BannerModel().ListAll();
            var Productmodels = new ProductModel();
            ViewBag.NewProduct = Productmodels.ListNewProduct(4);
            ViewBag.LitsTopView = Productmodels.ListTopHot(4);
            ViewBag.LitsTopSell = Productmodels.ListTopSell(4);
            ViewBag.LitsTopYasui = Productmodels.ListTopyasui(4);
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var dm = new CategoryModel();
            var model = dm.ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Topmenu()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult CountCart()
        {
            var cart = Session[CastSession];
            var list = new List<CartModel>();
            if (cart != null)
            {
                list = (List<CartModel>)cart;
            }
            return PartialView(list);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterModel().GetFooter();
            return PartialView(model);
        }
        
	}
}