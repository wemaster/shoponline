namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblProduct")]
    public partial class TblProduct
    {
        [Key]
        public int IDSP { get; set; }

        [StringLength(250)]
        public string NameSP { get; set; }

        [StringLength(250)]
        public string Metatitle { get; set; }

        public string Desription { get; set; }

        public int? IDCate { get; set; }

        [StringLength(250)]
        public string Img { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        public DateTime? DayInput { get; set; }

        public decimal? Promotion { get; set; }

        public decimal? Price { get; set; }

        public int? NumInput { get; set; }

        public int? NumView { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public bool? Status { get; set; }

        [StringLength(250)]
        public string Metakeywords { get; set; }

        [StringLength(250)]
        public string Metadescription { get; set; }

        [StringLength(250)]
        public string Tags { get; set; }
    }
}
