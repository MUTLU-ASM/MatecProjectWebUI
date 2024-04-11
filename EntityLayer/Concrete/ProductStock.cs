using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductStock
    {
        public int ProductStockId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }

        public Product Product { get; set; }
    }
}
