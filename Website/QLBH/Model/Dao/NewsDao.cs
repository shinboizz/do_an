using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NewsDao
    {
        MyDB db = new MyDB();
        public List<TinTuc> GetList()
        {
            List<TinTuc> list = new List<TinTuc>();
            list = db.TinTucs.ToList();
            return list;
        }
        public TinTuc Find(long id)
        {
            return db.TinTucs.Find(id);
        }
        public long Insert(TinTuc entity)
        {
            db.TinTucs.Add(entity);
            db.SaveChanges();
            return entity.MaTin;
        }
        public bool Update(TinTuc entity)
        {
            var Tin = db.TinTucs.Find(entity.MaTin);
            Tin.TieuDe = entity.TieuDe;
            Tin.MaLoaiTin = entity.MaLoaiTin;
            Tin.MoTa = entity.MoTa;
            Tin.NoiDung = entity.NoiDung;
            Tin.Anh = entity.Anh;
            Tin.NgaySua = DateTime.Now;
            db.SaveChanges();
            return true;
        }
        public bool Delete(long id)
        {
            try
            {
                var Tin = db.TinTucs.Find(id);
                db.TinTucs.Remove(Tin);
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
