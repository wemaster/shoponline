using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class ProductModel
    {
        public OnlineShopDbContext context = new OnlineShopDbContext();
        public List<TblProduct> ListNewProduct(int top)
        {
            return context.TblProducts.OrderByDescending(x => x.DayInput).Take(top).ToList();
        }
        public List<TblProduct> ListTopHot(int top)
        {
            return context.TblProducts.Where(x => x.NumView != null).OrderByDescending(y => y.DayInput).Take(top).ToList();
        }
        public List<TblProduct> ListTopSell(int top)
        {
            return context.TblProducts.Where(x => x.Promotion != null && x.DayInput >= DateTime.Now).OrderByDescending(y => y.DayInput).Take(top).ToList();
        }
        public List<TblProduct> ListTopyasui(int top)
        {
            return context.TblProducts.Where(x => x.Promotion != null && x.Promotion <300000).OrderByDescending(y => y.DayInput).Take(top).ToList();
        }
        public TblProduct ViewAll(int id)
        {
            return context.TblProducts.Find(id);
        }
    }
}