﻿using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductViewAll(int id)
        {
            var Product = new ProductModel().ViewAll(id);
            return View(Product);
        }
        public ActionResult DetailView(int id)
        {
            var Product = new ProductModel().ViewAll(id);
            return View(Product);
        }
	}
}