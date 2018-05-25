namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblAccount")]
    public partial class TblAccount
    {
        [Key]
        public int IDAcc { get; set; }

        [Required(ErrorMessage = "*Điền tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(50)]
        public string NameAcc { get; set; }

        [Required(ErrorMessage = "*Điền mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [StringLength(50)]
        public string PassAcc { get; set; }

        [Required(ErrorMessage = "*Chọn chức vụ")]
        [Display(Name = "Chức vụ")]
        public int? IDPer { get; set; }

        public int? CountView { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? DayReg { get; set; }

        [Display(Name = "Số điện thoại liên hệ")]
        [StringLength(50)]
        public string SDT { get; set; }
    }
}
