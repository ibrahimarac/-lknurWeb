using Ilknur.Core.Domain.Entities;
using Ilknur.Data.Sql.DbMappings;
using Ilknur.Data.Sql.Seeder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Data.Sql
{
    public class IlknurContext:DbContext
    {
        public IlknurContext(DbContextOptions opt):base(opt){
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryMapping());

            modelBuilder.SeedCategories();
        }



    }
}
