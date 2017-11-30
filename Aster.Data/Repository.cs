using Aster.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Data {
    public class Repository<T> : IRepository<T>, IRepositoryAsync<T> where T : BaseEntity {

        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext) {
            _dbContext = dbContext;
        }
        
        public T Add(T entity) {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity) {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Delete(T entity) {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity) {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public T GetById(int id) {
            return _dbContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id) {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public T GetSingle(IFilter<T> filter) {
            return List(filter)
                .FirstOrDefault();
        }
        
        public IEnumerable<T> List(IFilter<T> filter) {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = filter.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = filter.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                .Where(filter.Criteria).AsEnumerable();
        }


        public async Task<T> GetSingleAsync(IFilter<T> filter) {
            return (await ListAsync(filter)).FirstOrDefault();
        }
        

        public async Task<List<T>> ListAsync(IFilter<T> filter) {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = filter.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = filter.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                .Where(filter.Criteria)
                .ToListAsync();
        }



        public IEnumerable<T> ListAll() {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<List<T>> ListAllAsync() {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public void Update(T entity) {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity) {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}