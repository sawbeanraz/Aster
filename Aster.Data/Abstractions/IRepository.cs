using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Data.Abstractions {
    public interface IRepository<T> where T : BaseEntity {
        T GetById(int id);
        T GetSingle(IFilter<T> filter);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(IFilter<T> filter);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
