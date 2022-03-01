namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name ="Mã sản phẩm")]
        public string MaSP { get; set; }
        [Display(Name ="Loại sản phẩm")]
        public long? MaLoaiSP { get; set; }

        [StringLength(100)]
        [Display(Name ="Tên sản phẩm")]
        public string TenSP { get; set; }
        [Display(Name ="Số lượng")]
        public int? SoLuong { get; set; }
        [Display(Name ="Đơn giá")]
        public int? DonGia { get; set; }

        [StringLength(50)]
        [Display(Name ="Ảnh")]
        public string Anh { get; set; }

        [StringLength(50)]
        public string Anh1 { get; set; }

        [StringLength(50)]
        public string Anh2 { get; set; }

        [StringLength(50)]
        public string Anh3 { get; set; }

        [StringLength(200)]
        [Display(Name ="Mô tả")]
        public string MoTa { get; set; }
        [Display(Name ="Chi tiết")]
        public string ChiTiet { get; set; }
        [Display(Name ="Trạng thái")]
        public int? Status { get; set; }
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
