namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=Web_QLBH")
        {
        }

        public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<GioiThieu> GioiThieux { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<LoaiTin> LoaiTins { get; set; }
        public virtual DbSet<NhomNguoiDung> NhomNguoiDungs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietGioHang>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietGioHang>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.ChiTietGioHangs)
                .WithRequired(e => e.GioHang)
                .HasForeignKey(e => e.IDGioHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiSanPham>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiSanPham>()
                .Property(e => e.NguoiSua)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiTin>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiTin>()
                .Property(e => e.NguoiSua)
                .IsUnicode(false);

            modelBuilder.Entity<NhomNguoiDung>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<NhomNguoiDung>()
                .HasMany(e => e.TaiKhoans)
                .WithOptional(e => e.NhomNguoiDung)
                .HasForeignKey(e => e.IDQuyen);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.NguoiSua)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietGioHangs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TaiKhoan1)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.IDQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.NguoiSua)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.GioHangs)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.IDTaiKhoan);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.NguoiTao)
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.NguoiSua)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<Model.ViewModel.ProductViewModel> ProductViewModels { get; set; }
    }
}
