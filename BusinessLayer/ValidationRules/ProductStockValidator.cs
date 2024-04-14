using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductStockValidator : AbstractValidator<ProductStock>
    {
        public ProductStockValidator()
        {
            RuleFor(x => x.Stock).NotNull().NotEmpty().WithMessage("Stok Değeri Boş Geçilemez");
        }
    }
}
