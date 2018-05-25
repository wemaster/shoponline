namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblBanner")]
    public partial class TblBanner
    {
        [Key]
        public int IDbanner { get; set; }

        public string NameBaner { get; set; }

        [StringLength(250)]
        public string Img { get; set; }

        public string Detail { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        public DateTime? Createdate { get; set; }

        [StringLength(50)]
        public string UserCreate { get; set; }

        public bool? Status { get; set; }
    }
}
