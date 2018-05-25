using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopOnline.code
{
    [Serializable]
    public class AccountViewModel
    {
        public int IDAcc { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [StringLength(50)]
        public string NameAcc { get; set; }

        [Required(ErrorMessage = "*Chọn chức vụ")]
        [Display(Name = "Chức vụ")]
        public int? IDPermis { get; set; }

        public int? Countsee { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? DayRegister { get; set; }

        [Display(Name = "Số điện thoại liên hệ")]
        [StringLength(50)]
        public string SDT { get; set; }

        public string NamePer { get; set; }
    }
}