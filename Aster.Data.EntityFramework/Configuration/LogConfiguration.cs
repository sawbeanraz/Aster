using Aster.System.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aster.Data.EntityFramework.Configuration {
    public class LogConfiguration : DbEntityConfiguration<Log> {
        public override void Configure(EntityTypeBuilder<Log> entity) {
            entity.ToTable("Logs");
            entity.HasKey(l => l.Id);
            entity.Property(l => l.LogLevelId)
                .IsRequired(true);

            entity.Property(l => l.ShortMessage)
                .HasMaxLength(255)
                .IsRequired(true);

            entity.Property(l => l.FullMessage)
                .HasMaxLength(2500);
            entity.Property(l => l.Ip)
                .HasMaxLength(20);
            entity.Property(l => l.PageUrl)
                .HasMaxLength(500);
            entity.Property(l => l.ReferrerUrl)
                .HasMaxLength(500);
            entity.Property(l => l.Reference)
                .HasMaxLength(200);


            entity.Ignore(l => l.LogLevel);
        }
    }
}
