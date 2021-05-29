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
        }
    }

    public class NonTrackablePermanentEntityMapping<TEntity> : BaseEntityMapping<TEntity>
        where TEntity : NonTrackablePermanentEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
        }
    }

    public class TrackablePermanentEntityMapping<TEntity> : BaseEntityMapping<TEntity>
        where TEntity : TrackablePermanentEntity
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

            builder.Property(c => c.IsActive)
                .HasDefaultValueSql("1");
        }
    }

    public class TrackableTransientEntityMapping<TEntity> : BaseEntityMapping<TEntity>
        where TEntity : TrackableTransientEntity
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
