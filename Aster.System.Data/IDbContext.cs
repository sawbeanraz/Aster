using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.System.Data {
    public interface IDbContext {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        
        Task<int> SaveChangesAsync();
        
        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : BaseEntity, new();

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);
        
        void Detach(object entity);
        
        bool ProxyCreationEnabled { get; set; }

        bool AutoDetectChangesEnabled { get; set; }
    }
}