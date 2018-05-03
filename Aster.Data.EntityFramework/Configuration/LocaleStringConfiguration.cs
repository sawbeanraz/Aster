using Aster.Core.Domain.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Data.EntityFramework.Configuration
{
    public class LocaleStringConfiguration :  DbEntityConfiguration<LocaleString> {


        public override void Configure(EntityTypeBuilder<LocaleString> entity) {
            entity.ToTable("LocaleStrings");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.MsgId).HasMaxLength(1000).IsRequired();
            entity.Property(c => c.MsgStr).HasMaxLength(1000).IsRequired();
        }
    }
}
