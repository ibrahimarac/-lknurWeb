using Ilknur.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Data.Sql.DbMappings
{
    public class CategoryMapping : AuditableEntityMapping<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(30)")
                .IsRequired()
                .HasColumnName("CategoryName");

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey("CategoryId");
        }
    }
}
