using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Data {
    public interface IRepositoryAsync<T> where T : BaseEntity {

        Task<T> GetByIdAsync(object id);        
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);        
        Task DeleteAsync(IEnumerable<T> entities);
        IQueryable<T> List { get; }
        IQueryable<T> ListNoTracking { get; }
    }
}