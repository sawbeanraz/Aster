using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Aster.Data;
using Aster.Data.EntityFramework.Configuration;

/// <summary>
/// 1. Connects to database using connection string
/// 2. Load all auto mapping entities
/// 3. Able to execute store procedure and attach entity to DBContext
/// </summary>
namespace Aster.Data.EntityFramework {

  public class DataContext : DbContext, IDbContext {

    private readonly string _connectionString;
    private readonly IDataProvider _dataProvider;
    public DataContext(string connectionString, IDataProvider dataProvider) {
      _connectionString = connectionString.Replace(@"\\", @"\");
      _dataProvider = dataProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if(_dataProvider.GetType() == typeof(MySqlDataProvider)) {
          optionsBuilder.UseMySQL(_connectionString);
        } else if (_dataProvider.GetType() == typeof(SqlServerDataProvider)) {
          optionsBuilder.UseSqlServer(_connectionString);
        } else if (_dataProvider.GetType() == typeof(SqlCeDataProvider)) {
          throw new PlatformNotSupportedException();
        }
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity: BaseEntity {
      return base.Set<TEntity>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

      var configurationTypes = Assembly.GetExecutingAssembly().GetTypes()
        .Where(type => !string.IsNullOrEmpty(type.Namespace))
        .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
          type.BaseType.GetGenericTypeDefinition() == typeof(DbEntityConfiguration<>));

      foreach(var configType in configurationTypes) {
        dynamic configInstance = Activator.CreateInstance(configType);
        modelBuilder.ApplyConfiguration(configInstance);
      }

      base.OnModelCreating(modelBuilder);

    }

    protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity: BaseEntity, new() {
      var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
      if(alreadyAttached == null) {
          Set<TEntity>().Attach(entity);
          return entity;
      }
      return alreadyAttached;
    }

    public bool ProxyCreationEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool AutoDetectChangesEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Detach(object entity) {
      throw new NotImplementedException();
    }

    public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters) {
      throw new NotImplementedException();
    }

    public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new() {
      throw new NotImplementedException();
    }

    public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters) {
      throw new NotImplementedException();
    }

    public async Task<int> SaveChangesAsync() {
      return await base.SaveChangesAsync(CancellationToken.None);      
    }
  }
}
