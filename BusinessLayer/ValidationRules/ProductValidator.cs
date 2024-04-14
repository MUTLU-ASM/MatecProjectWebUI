using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty().WithMessage("Ürün Kodu Boş Geçilemez");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Ürün Adı Boş Geçilemez");
            RuleFor(x => x.Image).NotNull().NotEmpty().WithMessage("Ürün Resmi Boş Geçilemez");
        }
    }
}
