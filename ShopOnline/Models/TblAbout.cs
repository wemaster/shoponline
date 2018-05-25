namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblAbout")]
    public partial class TblAbout
    {
        [Key]
        public int IDAbout { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Metatitle { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string UserCreate { get; set; }

        [StringLength(250)]
        public string Metakeyword { get; set; }

        [StringLength(250)]
        public string Metadescription { get; set; }

        public bool? Stattus { get; set; }
    }
}
