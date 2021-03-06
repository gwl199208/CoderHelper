﻿using System;
using System.Collections.Generic;
using System.Linq;
using Coder.Core.Service;
using Coder.Core.Repository;
using Coder.Resources;

namespace Coder.Service
{
    public class CrudService<T> : ICrudService<T>
    {
        #region 注入 IRepository
        protected IRepository<T> repo;
        public CrudService(IRepository<T> repo)
        {
            this.repo = repo;
        }
        #endregion

        public T Create(T e)
        {
            var u = repo.Insert(e);
            repo.Save();
            return u;
        }

        public int Save()
        {
            return repo.Save();
        }

        public T Delete(int id)
        {
            var u = repo.Delete(repo.Get(id));
            repo.Save();
            return u;
        }

        public T Get(int id)
        {
            return repo.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return repo.GetAll();
        }

        public IEnumerable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> func)
        {
            throw new NotImplementedException();
        }

    }
}
