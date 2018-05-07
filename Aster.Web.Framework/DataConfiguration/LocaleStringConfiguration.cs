using Aster.System.Data.EntityFramework;
using Aster.System.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aster.Web.Framework.DataConfiguration {
    public class LocaleStringConfiguration : DbEntityConfiguration<LocaleString> {

        public override void Configure(EntityTypeBuilder<LocaleString> entity) {
            entity.ToTable("LocaleStrings");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.MsgId).HasMaxLength(1000).IsRequired();
            entity.Property(c => c.MsgStr).HasMaxLength(1000).IsRequired();
        }
    }
}
