using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SlideDao
    {
        MyDB db = new MyDB();
        public List<Slide> GetList()
        {
            List<Slide> list = new List<Slide>();
            list = db.Slides.ToList();
            return list;
        }
    }
}
