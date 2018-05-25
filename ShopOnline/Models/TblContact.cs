namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblContact")]
    public partial class TblContact
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentCT { get; set; }

        public bool? Status { get; set; }
    }
}
