using Aster.Core.Domain.Contractors;
using Aster.System.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aster.Web.Framework.DataConfiguration
{
    public class ContractorBankAccountConfiguration : DbEntityConfiguration<ContractorBankAccount> {

        public override void Configure(EntityTypeBuilder<ContractorBankAccount> entity) {
            entity.ToTable("ContractorBankAccounts");
            entity.HasKey(c => c.Id);
        }
    }    
}
