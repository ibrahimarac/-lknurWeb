using Ilknur.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Data.Sql.DbMappings
{
    public class BaseEntityMapping<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity: BaseEntity
    { 
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(c => c.IsActive)
                .IsRequired(false)
                .HasDefaultValueSql("1");
        }
    }
}
