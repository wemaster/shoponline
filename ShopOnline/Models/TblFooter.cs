namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblFooter")]
    public partial class TblFooter
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public bool? Status { get; set; }
    }
}
