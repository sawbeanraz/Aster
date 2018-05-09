﻿using Aster.Core.Domain.Security;
using Aster.System.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aster.Web.Framework.DataConfiguration {
    public class UserConfiguration : DbEntityConfiguration<User> {

        public override void Configure(EntityTypeBuilder<User> entity) {
            entity.ToTable("Users");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.UserName).HasMaxLength(255).IsRequired();
        }
    }
}