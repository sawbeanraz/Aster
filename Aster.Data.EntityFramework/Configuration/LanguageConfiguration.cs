using Aster.Core.Domain.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Data.EntityFramework.Configuration
{
    public class LanguageConfiguration: DbEntityConfiguration<Language> {

        public override void Configure(EntityTypeBuilder<Language> entity) {
            entity.ToTable("Languages");
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Name).HasMaxLength(100).IsRequired();
            entity.Property(l => l.LanguageCulture).HasMaxLength(10).IsRequired();
        }
    }    
}
