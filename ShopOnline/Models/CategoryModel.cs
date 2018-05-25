using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class CategoryModel
    {
        private OnlineShopDbContext context = new OnlineShopDbContext();
        public List<TblCategory> ListAll()
        {
            var list = context.Database.SqlQuery<TblCategory>("Pr_CategoryView").ToList();
            return list;
        }
    }
}