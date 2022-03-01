using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class UserGroupDao
    {
        MyDB db = new MyDB();
        public List<NhomNguoiDung> GetList()
        {
            return db.NhomNguoiDungs.ToList();
        }
    }
}
