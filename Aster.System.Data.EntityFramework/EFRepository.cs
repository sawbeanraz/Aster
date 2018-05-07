using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aster.System.Data;

namespace Aster.System.Data.EntityFramework {
    public class EFRepository<T> : IRepositoryAsync<T> where T : BaseEntity {

        private readonly IDbContext _context;
        private DbSet<T> _entities;

        public EFRepository(IDbContext context) {
            _context = context;
        }

        public IQueryable<T> List {
            get {
                return Entities;
            }
        }

        public IQueryable<T> ListNoTracking {
            get {
                return Entities.AsNoTracking();
            }
        }


        public async Task DeleteAsync(T entity) {
            try {
                if(entity == null) {
                    throw new ArgumentNullException(nameof(entity));
                }
                Entities.Remove(entity);
                await _context.SaveChangesAsync();

            } catch(DbUpdateException dbEx) {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        public async Task DeleteAsync(IEnumerable<T> entities) {
            try {
                if(entities == null) {
                    throw new ArgumentNullException(nameof(entities));
                }

                foreach(var entity in entities) {
                    Entities.Remove(entity);
                }
                await _context.SaveChangesAsync();
            } catch(DbUpdateException dbEx) {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        public async Task<T> GetByIdAsync(object id) {
            return await Task.FromResult(
                Entities.Find(id)
            );
        }

        public async Task<T> InsertAsync(T entity) {
            try {
                if(entity == null) {
                    throw new ArgumentNullException(nameof(entity));
                }

                Entities.Add(entity);
                await _context.SaveChangesAsync();
                return entity;

            } catch(DbUpdateException dbEx) {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        public async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities) {

            try {
                if(entities == null) {
                    throw new ArgumentNullException(nameof(entities));
                }

                foreach(var entity in entities) {
                    Entities.Add(entity);
                }
                await _context.SaveChangesAsync();

                return entities;
            } catch(DbUpdateException dbEx) {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        public async Task UpdateAsync(T entity) {
            try {
                if(entity == null) {
                    throw new ArgumentNullException(nameof(entity));
                }
                //_context.Entry(entity).State = EntityState.Modified;                
                await _context.SaveChangesAsync();
            } catch(DbUpdateException dbEx) {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        public async Task UpdateAsync(IEnumerable<T> entities) {
            try {
                if(entities == null) {
                    throw new ArgumentNullException(nameof(entities));
                }
                await _context.SaveChangesAsync();
            } catch(DbUpdateException dbEx) {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException dbEx) {
            var fullErrorText = GetFullErrorText(dbEx);

            foreach(var entry in dbEx.Entries) {
                if(entry == null)
                    continue;
                //rollback of entity changes
                entry.State = EntityState.Unchanged;
            }
            _context.SaveChangesAsync();
            return fullErrorText;
        }

        protected string GetFullErrorText(DbUpdateException exc) {
            var msg = string.Empty;
            foreach(var entry in exc.Entries) {
                msg += $"Property: {entry.ToString()} Error: {exc.Message}" + Environment.NewLine;
            }
            return msg;
        }

        protected virtual DbSet<T> Entities {
            get {
                if(_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}