using App.Contracts.Commands.Settings;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Validation
{
    public class AddUpdateSliderCommandValid : AbstractValidator<AddUpdateSliderCommand>
    {
        public AddUpdateSliderCommandValid()
        {
            RuleFor(x => x.File).NotNull().NotEmpty();
            RuleFor(x => x.FileName).NotEmpty();
        }
    }
}
