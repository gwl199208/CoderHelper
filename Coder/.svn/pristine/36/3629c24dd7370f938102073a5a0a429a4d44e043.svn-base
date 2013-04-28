using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace Coder.Core.Service
{
    public interface ICrudService<T>
    {
        T Create(T e);
        int Save();
        T Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> func);
    }
}
