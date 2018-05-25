namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblFeedback")]
    public partial class TblFeedback
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Adre { get; set; }

        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public bool? Status { get; set; }
    }
}
