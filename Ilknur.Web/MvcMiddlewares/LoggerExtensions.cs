using Ilknur.Core.Loggers;
using Ilknur.Core.Services;
using Ilknur.Services.Services;
using Ilknur.Utils.Loggers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.MvcMiddlewares
{
    public static class LoggerExtensions
    {
        public static IServiceCollection AddLoggers(this IServiceCollection services)
        {
            return
                services
                    .AddScoped<IExceptionLogger, DbExceptionLogger>()
                    .AddScoped<ICrudOperationLogger, DbCrudOperationLogger>();
        }
    }
}
