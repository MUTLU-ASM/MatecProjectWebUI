using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UnitTypeValidator : AbstractValidator<UnitType>
    {
        public UnitTypeValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Birim Cinsi Adı Boş Geçilemez");
        }
    }
}
