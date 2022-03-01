using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using Model.ViewModel;

namespace Model.Dao
{
    public class ProductDao
    {
        MyDB db = new MyDB();
        public List<SanPham> GetByStatus(int status)
        {
            List<SanPham> list = new List<SanPham>();
            list = db.SanPhams.Where(x=>x.Status==status).ToList();
            return list;
        }
        public IEnumerable<SanPham> GetList(int page,int pagesize)
        {
            IEnumerable<SanPham> list = new List<SanPham>();
            list = db.SanPhams.OrderByDescending(x=>x.NgayTao).ToPagedList(page,pagesize);
            return list;
        }
        public List<SanPham> GetByIDCat(long idCat)
        {
            List<SanPham> list = new List<SanPham>();
            list = db.SanPhams.Where(x=>x.MaLoaiSP==idCat).ToList();
            return list;
        }
        public SanPham Find(string id)
        {
            return db.SanPhams.Find(id);
        }
        public string Insert(SanPham entity)
        {
            db.SanPhams.Add(entity);
            db.SaveChanges();
            return entity.MaSP;
        }
        public bool Update(SanPham entity)
        {
            var sanpham = db.SanPhams.Find(entity.MaSP);
            sanpham.TenSP = entity.TenSP;
            sanpham.SoLuong = entity.SoLuong;
            sanpham.DonGia = entity.DonGia;
            sanpham.Anh = entity.Anh;
            sanpham.MaLoaiSP = entity.MaLoaiSP;
            sanpham.MoTa = entity.MoTa;
            sanpham.ChiTiet = entity.ChiTiet;
            sanpham.NgaySua = DateTime.Now;
            sanpham.NguoiSua = entity.NguoiSua;
            db.SaveChanges();
            return true;
        }
        public bool Delete(string id)
        {
            try
            {
                var sanpham = db.SanPhams.Find(id);
                db.SanPhams.Remove(sanpham);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<string> ListName(string keyword)
        {
            return db.SanPhams.Where(x => x.TenSP.Contains(keyword)).Select(x => x.TenSP).ToList();
        }
        public List<ProductViewModel> Search(string keyword,ref int totalRecord,int pageIndex=1,int pageSize=2)
        {
            totalRecord = db.SanPhams.Where(x => x.TenSP.Contains(keyword)).Count();
            var model = (from a in db.SanPhams
                        join b in db.LoaiSanPhams
                        on a.MaLoaiSP equals b.MaLoaiSP
                        where a.TenSP.Contains(keyword)
                        select new 
                        {
                            CateName = b.TenLoaiSP,
                            CreateDate = a.NgayTao,
                            ID = a.MaSP,
                            Images = a.Anh,
                            Name = a.TenSP,
                            Price = a.DonGia,
                            Describe=a.MoTa
                        }).AsEnumerable().Select(x=>new ProductViewModel() {
                            CateName = x.Name,
                            CreateDate = x.CreateDate,
                            ID = x.ID,
                            Images = x.Images,
                            Name = x.Name,
                            Price = x.Price,
                            Describe = x.Describe
                        });
            model.OrderByDescending(x => x.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}
