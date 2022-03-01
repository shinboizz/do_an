using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class AboutDao
    {
        MyDB db = new MyDB();
        public List<GioiThieu> GetList()
        {
            List<GioiThieu> list = new List<GioiThieu>();
            list = db.GioiThieux.ToList();
            return list;
        }
        public long Insert(GioiThieu entity)
        {
            db.GioiThieux.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public GioiThieu Find(long id)
        {
            return db.GioiThieux.Find(id);
        }
        public bool Update(GioiThieu entity)
        {
            var about = db.GioiThieux.Find(entity.ID);
            about.TieuDe = entity.TieuDe;
            about.Anh = entity.Anh;
            about.ChiTiet = entity.ChiTiet;
            
            db.SaveChanges();
            return true;
        }
        public bool Delete(long id)
        {
            try
            {
                var about = db.GioiThieux.Find(id);
                db.GioiThieux.Remove(about);
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
