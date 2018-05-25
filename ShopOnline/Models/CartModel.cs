using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    [Serializable]
    public class CartModel
    {
        public TblProduct ProductID { get; set; }
        public int Quantity { get; set; }
        public int TotalPay { get; set; }
    }
}