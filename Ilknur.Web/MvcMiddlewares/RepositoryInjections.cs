using Ilknur.Core.Repositories;
using Ilknur.Data.Sql.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.MvcMiddlewares
{
    public static class RepositoryInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return
                services
                    .AddScoped<ICategoryRepository, CategoryRepository>()
                    .AddScoped<IErrorRepository, ErrorRepository>()
                    .AddScoped<ICrudLoggerRepository, CrudLoggerRepository>();
        }
    }
}
