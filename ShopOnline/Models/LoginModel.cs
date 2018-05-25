using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Chưa điền tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage="Vui lòng điền mật khẩu")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}