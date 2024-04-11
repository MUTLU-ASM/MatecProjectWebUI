using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UnitType
    {
        public int UnitTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<ProductPrice> ProductPrices { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
    }
}
