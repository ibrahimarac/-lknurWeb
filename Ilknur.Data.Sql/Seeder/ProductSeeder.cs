using Ilknur.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Data.Sql.Seeder
{
    public static class ProductSeeder
    {
        public static void SeedProducts (this ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasData(
                new Product
                {
                    Id=1,CategoryId=1,Name="Ürün 1"
                },
                new Product
                {
                    Id = 2, CategoryId = 1, Name = "Ürün 2"
                },
                new Product
                {
                    Id = 3, CategoryId = 2, Name = "Ürün 3"
                },
                new Product
                {
                    Id = 4, CategoryId = 3, Name = "Ürün 2"
                }
            );
        }
    }
}
