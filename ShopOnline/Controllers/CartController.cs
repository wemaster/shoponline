using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace ShopOnline.Controllers
{
    public class CartController : Controller
    {
        public const string CastSession = "CastSession";
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            var cart = Session[CastSession];
            var list = new List<CartModel>();
            if (cart != null)
            {
                list = (List<CartModel>)cart;
            }
            return View(list);
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartModel>)Session[CastSession];
            sessionCart.RemoveAll(x => x.ProductID.IDSP == id);
            Session[CastSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        //public JsonResult Update(string cartModel)
        //{
        //    var jsonCart = new JavaScriptSerializer().Deserialize<List<CartModel>>(cartModel);
        //    var sessionCart = (List<CartModel>)Session[CastSession];

        //    foreach (var item in sessionCart)
        //    {
        //        var jsonItem = jsonCart.FirstOrDefault(x=>x.ProductID.IDSP == item.ProductID.IDSP);
        //        if (jsonItem != null)
        //        {
        //            item.Quantity = jsonItem.Quantity;
        //        }
        //    }
        //    Session[CastSession] = sessionCart;
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}
        [HttpGet]
        public ActionResult Update()
        {
            var cart = Session[CastSession];
            var list = new List<CartModel>();
            if (cart != null)
            {
                list = (List<CartModel>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Update(FormCollection fc)
        {
            string[] quantities = fc.GetValues("quantity");
            List<CartModel> cart = (List<CartModel>)Session[CastSession];
            for (int i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = Convert.ToInt32(quantities[i]);
                if (cart[i].ProductID.Promotion != null)
                {
                    cart[i].TotalPay = Convert.ToInt32(cart[i].Quantity * cart[i].ProductID.Promotion);
                }
                else
                {
                    cart[i].TotalPay = Convert.ToInt32(cart[i].Quantity * cart[i].ProductID.Price);
                }
            }
            Session[CastSession] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult AddItem(int productId, int quantiy)
        {
            var product = new ProductModel().ViewAll(productId);
            var cart = Session[CastSession];
            if (cart != null)//kiểm tra cart đã có hàng trong đó chưa?
            {
                var list = (List<CartModel>)cart;
                if (list.Exists(x => x.ProductID.IDSP == productId))
                {
                    foreach (var item in list)
                    {

                        if (item.ProductID.IDSP == productId)
                        {
                            item.Quantity += quantiy;
                            if (item.ProductID.Promotion != null)
                            {
                                item.TotalPay = Convert.ToInt32(item.Quantity * item.ProductID.Promotion);
                            }
                            else
                            {
                                item.TotalPay = Convert.ToInt32(item.Quantity * item.ProductID.Price);
                            }
                        }
                    }
                }
                else
                {
                    //Tạo mới gio hàng
                    var item = new CartModel();
                    item.ProductID = product;
                    item.Quantity = quantiy;
                    if (item.ProductID.Promotion != null)
                    {
                        item.TotalPay = Convert.ToInt32(item.Quantity * item.ProductID.Promotion);
                    }
                    else
                    {
                        item.TotalPay = Convert.ToInt32(item.Quantity * item.ProductID.Price);
                    }
                    list.Add(item);
                    Session[CastSession] = list;
                }
            }
            else
            {
                //Tạo mới gio hàng
                var item = new CartModel();
                item.ProductID = product;
                item.Quantity = quantiy;
                if(item.ProductID.Promotion != null)
                {
                    item.TotalPay = Convert.ToInt32(item.Quantity * item.ProductID.Promotion);
                }
                else
                {
                    item.TotalPay = Convert.ToInt32(item.Quantity * item.ProductID.Price);
                }
                var list = new List<CartModel>();
                list.Add(item);
                Session[CastSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}