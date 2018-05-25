using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class PerModel
    {
        public OnlineShopDbContext context = new OnlineShopDbContext();
        public List<TblPer> ListAll()
        {
            var list = context.Database.SqlQuery<TblPer>("").ToList();
            return list;
        }
    }
}