using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        MyDB db = new MyDB();
        public long Insert(GioHang order)
        {
            db.GioHangs.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}
