using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductPrice
    {
        public int ProductPriceId { get; set; }
        public int ProductId { get; set; }
        public int UnitTypeId { get; set; }
        public double Price { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime ValidityDate { get; set; }
        public byte Status { get; set; }

        public UnitType UnitType { get; set; }
        public Product Product { get; set; }
    }
}
