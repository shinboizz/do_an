namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioiThieu")]
    public partial class GioiThieu
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name ="Tiêu đề")]
        public string TieuDe { get; set; }

        [StringLength(50)]
        [Display(Name ="Ảnh")]
        public string Anh { get; set; }
        [Display(Name ="Chi tiết")]
        public string ChiTiet { get; set; }
    }
}
