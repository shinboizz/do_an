using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        MyDB db = new MyDB();
        public List<LoaiSanPham> GetList()
        {
            List<LoaiSanPham> list = new List<LoaiSanPham>();
            list = db.LoaiSanPhams.ToList();
            return list;
        }
        public LoaiSanPham Find(long id)
        {
            return db.LoaiSanPhams.Find(id);
        }
        public long Insert(LoaiSanPham entity)
        {
            db.LoaiSanPhams.Add(entity);
            db.SaveChanges();
            return entity.MaLoaiSP;
        }
        public bool Update(LoaiSanPham entity)
        {
            var LoaiSP = db.LoaiSanPhams.Find(entity.MaLoaiSP);
            LoaiSP.TenLoaiSP = entity.TenLoaiSP;
            LoaiSP.NgaySua = DateTime.Now;
            LoaiSP.NguoiSua = entity.NguoiSua;
            db.SaveChanges();
            return true;
        }
        public bool Delete(long id)
        {
            try
            {
                var LoaiSP = db.LoaiSanPhams.Find(id);
                db.LoaiSanPhams.Remove(LoaiSP);
                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
           
        }
    }
}
