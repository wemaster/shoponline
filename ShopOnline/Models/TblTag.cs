namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TblTag
    {
        [Key]
        [StringLength(50)]
        public string IDTags { get; set; }

        [StringLength(50)]
        public string NameTags { get; set; }
    }
}
