namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblNote")]
    public partial class TblNote
    {
        [Key]
        public int IDNote { get; set; }

        public string NameNote { get; set; }

        public string Detail { get; set; }

        [StringLength(50)]
        public string NameAcc { get; set; }

        public DateTime? DateNote { get; set; }
    }
}
