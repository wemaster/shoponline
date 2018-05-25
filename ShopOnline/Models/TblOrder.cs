namespace ShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblOrder")]
    public partial class TblOrder
    {
        public int ID { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CustomID { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; }

        [StringLength(50)]
        public string ShipMoble { get; set; }

        [StringLength(250)]
        public string ShipAdress { get; set; }

        public int? Status { get; set; }
    }
}
