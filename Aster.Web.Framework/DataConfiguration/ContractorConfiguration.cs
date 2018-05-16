using Aster.Core.Domain.Contractors;
using Aster.System.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aster.Web.Framework.DataConfiguration {
    public class ContractorConfiguration : DbEntityConfiguration<Contractor> {

        public override void Configure(EntityTypeBuilder<Contractor> entity) {
            entity.ToTable("Contractors");
            entity.HasKey(c => c.Id);
        }
    }
}