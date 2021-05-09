using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.ServiceInjection
{
    public static class DbInjectons
    {
        public static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder();
                return builder.Build();
            }
        }

        public static IServiceCollection CreateDbContext<T>(this IServiceCollection services)
            where T:DbContext
        {
            return services.AddDbContext<T>(opt =>
            {                
                opt.UseSqlServer(Configuration.GetConnectionString("LocalSql"));
            });
        }
    }
}
