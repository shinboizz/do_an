namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            GioHangs = new HashSet<GioHang>();
        }

        public long ID { get; set; }

        [Column("TaiKhoan")]
        [StringLength(50)]
        [Display(Name ="Tài khoản")]
        public string TaiKhoan1 { get; set; }

        [StringLength(50)]
        [Display(Name ="Mật khẩu")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        [Display(Name ="Quyền")]
        public string IDQuyen { get; set; }

        [StringLength(50)]
        [Display(Name ="Tên")]
        public string Ten { get; set; }

        [StringLength(50)]
        [Display(Name ="Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(50)]
        [Display(Name ="Giới tính")]
        public string GioiTinh { get; set; }
        [Display(Name ="Ngày sinh")]
        public DateTime? NgaySinh { get; set; }
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
        [Display(Name ="Trạng thái")]
        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        public virtual NhomNguoiDung NhomNguoiDung { get; set; }
    }
}
