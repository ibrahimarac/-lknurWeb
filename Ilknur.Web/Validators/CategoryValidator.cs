﻿using FluentValidation;
using Ilknur.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Validators
{
    public class CategoryValidator:AbstractValidator<CategoryVM>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Kategori adı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
                //.MaximumLength(30).WithMessage("Kategori adı en fazla 30 karakter olabilir.");
        }
    }
}
