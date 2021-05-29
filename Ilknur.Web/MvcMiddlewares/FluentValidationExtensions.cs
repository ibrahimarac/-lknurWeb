using FluentValidation;
using FluentValidation.AspNetCore;
using Ilknur.Web.Models.VM;
using Ilknur.Web.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.MvcMiddlewares
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            return
                services
                    .AddFluentValidation()
                    .AddTransient<IValidator<CategoryVM>, CategoryValidator>();
        }
    }
}
