using Aster.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Aster.Data.EntityFramework.Configuration {


  public class UserConfiguration : DbEntityConfiguration<User> {

    public override void Configure(EntityTypeBuilder<User> entity) {      
        entity.ToTable("User");
        entity.HasKey(c => c.Id);
        entity.Property(c => c.UserName).HasMaxLength(255).IsRequired();          
    }

  }
}