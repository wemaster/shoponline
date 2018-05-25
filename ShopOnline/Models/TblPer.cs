namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblPer")]
    public partial class TblPer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPer { get; set; }

        [StringLength(50)]
        public string NamePer { get; set; }
    }
}
