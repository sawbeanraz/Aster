using Microsoft.EntityFrameworkCore;

namespace Aster.Data.EntityFramework {

  public static class ModelBuilderExtensions {

    public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, 
      DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class {

        modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
    }
  }
}