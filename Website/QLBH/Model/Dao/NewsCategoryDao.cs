using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class NewsCategoryDao
    {
        MyDB db = new MyDB();
        public List<LoaiTin> GetList()
        {
            List<LoaiTin> list = new List<LoaiTin>();
            list = db.LoaiTins.ToList();
            return list;
        }
        public LoaiTin Find(long id)
        {
            return db.LoaiTins.Find(id);
        }
        public long Insert(LoaiTin entity)
        {
            db.LoaiTins.Add(entity);
            db.SaveChanges();
            return entity.MaLoaiTin;
        }
        public bool Update(LoaiTin entity)
        {
            var Loaitin = db.LoaiTins.Find(entity.MaLoaiTin);
            Loaitin.TenLoaiTin = entity.TenLoaiTin;
            Loaitin.NgaySua = DateTime.Now;
            db.SaveChanges();
            return true;
        }
        public bool Delete(long id)
        {
            try
            {
                var Loaitin = db.LoaiTins.Find(id);
                db.LoaiTins.Remove(Loaitin);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
