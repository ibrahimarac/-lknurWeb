using Ilknur.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Data.Sql.DbMappings
{
    public class AuditableEntityMapping<TEntity> : BaseEntityMapping<TEntity>
        where TEntity:AuditableEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

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
        }
    }
}
