namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSanPham")]
    public partial class LoaiSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Display(Name ="Mã loại")]
        public long MaLoaiSP { get; set; }

        [StringLength(50)]
        [Display(Name ="Tên loại")]
        public string TenLoaiSP { get; set; }
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
