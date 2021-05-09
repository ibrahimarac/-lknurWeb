using Ilknur.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.DbMappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(30)")
                .IsRequired()
                .HasColumnName("CategoryName");

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey("CategoryId");

            builder.Property(c => c.LastupUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(c => c.CreateUser)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(c => c.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.LastupDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.IsActive)
                .IsRequired(false)
                .HasDefaultValueSql("1");
        }
    }
}
