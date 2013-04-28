using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Coder.Core.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        T Insert(T o);
        int Save();
        T Delete(T o);
    }
}
