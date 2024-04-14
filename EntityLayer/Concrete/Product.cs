using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string Image { get; set; }
        public byte Status { get; set; }

        public Company Company { get; set; }
        public ProductPrice ProductPrice { get; set; }
        public ProductStock ProductStock { get; set; }
    }
}
