﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aster.System.Data.EntityFramework {
    public abstract class DbEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class {

        public abstract void Configure(EntityTypeBuilder<TEntity> entity);

    }
}