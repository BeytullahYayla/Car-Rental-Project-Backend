using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);//Daily price must be greater than 0
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(400).When(p => p.BrandID == 1);
        }

    }
}
