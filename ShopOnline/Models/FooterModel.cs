using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class FooterModel
    {
        private OnlineShopDbContext context = null;
        public FooterModel()
        {
            context = new OnlineShopDbContext();
        }
        public TblFooter GetFooter()
        {
            return context.TblFooters.SingleOrDefault(x => x.Status == true);
        }
    }
}