using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aster.Data.EntityFramework {
  public  abstract class DbEntityConfiguration<TEntity> where TEntity : class {     

      public abstract void Configure(EntityTypeBuilder<TEntity> entity);      
      
  }
}