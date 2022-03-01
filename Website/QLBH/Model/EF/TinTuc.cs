namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [Display(Name ="Mã tin")]
        public long MaTin { get; set; }
        [Display(Name ="Loại tin")]
        public long? MaLoaiTin { get; set; }

        [StringLength(200)]
        [Display(Name ="Tiêu đề")]
        public string TieuDe { get; set; }

        [StringLength(200)]
        [Display(Name ="Mô tả")]
        public string MoTa { get; set; }
        [Display(Name ="Nội dung")]
        public string NoiDung { get; set; }

        [StringLength(50)]
        [Display(Name ="Ảnh")]
        public string Anh { get; set; }

        [Display(Name ="Ngày tạo")]
        public DateTime? NgayTao { get; set; }

        [StringLength(50)]
        [Display(Name ="Người tạo")]
        public string NguoiTao { get; set; }
        [Display(Name ="Ngày sửa")]
        public DateTime? NgaySua { get; set; }

        [StringLength(50)]
        [Display(Name ="Người sửa")]
        public string NguoiSua { get; set; }

        public virtual LoaiTin LoaiTin { get; set; }
    }
}
