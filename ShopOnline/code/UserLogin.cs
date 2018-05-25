using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.code
{
    [Serializable]
    public class UserLogin
    {
        public int IDAcc { get; set; }
        public string NameAcc { get; set; }
    }
}