using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Data.Abstractions {
    public interface IRepositoryAsync<T> where T : BaseEntity {

        Task<T> GetByIdAsync(int id);
        Task<T> GetSingleAsync(IFilter<T> filter);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(IFilter<T> filter); 
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);        
    }
}