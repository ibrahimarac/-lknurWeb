using Ilknur.Core;
using Ilknur.Data.Sql;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.MvcMiddlewares
{
    public static class UnitOfWorkInjections
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitWork, UnitWork>();
        }
    }
}
