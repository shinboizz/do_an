using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ProductViewModel
    {
        public string ID { get; set; }
        public string Images { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string CateName { get; set; }
        public string Describe { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
