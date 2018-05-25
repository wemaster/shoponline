namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblCategory")]
    public partial class TblCategory
    {
        [Key]
        public int IDCate { get; set; }

        [StringLength(50)]
        public string NameCate { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string SEOTile { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string UserCreate { get; set; }

        [StringLength(250)]
        public string Metakeywords { get; set; }

        [StringLength(250)]
        public string Metadescription { get; set; }

        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }
    }
}
