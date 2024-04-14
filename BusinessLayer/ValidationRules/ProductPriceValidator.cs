using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductPriceValidator : AbstractValidator<ProductPrice>
    {
        public ProductPriceValidator()
        {
            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Ürün Kodu Boş Geçilemez");
            RuleFor(x => x.ValidityDate).NotNull().NotEmpty().NotEqual(Convert.ToDateTime("gg.aa.yyyy")).Must(date => date > DateTime.Now).WithMessage("Ürün Adı Boş Geçilemez");
        }
    }
}
