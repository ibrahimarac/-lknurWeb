using Ilknur.Web.DbMappings;
using Ilknur.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Context
{
    public class IlknurContext:DbContext
    {
        public IlknurContext(DbContextOptions opt):base(opt){
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryMapping());
            modelBuilder.ApplyConfiguration<Product>(new ProductMapping());
        }
    }
}
