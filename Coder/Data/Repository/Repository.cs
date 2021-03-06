﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Coder.Core.Repository;

namespace Coder.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class , new()
    {
        #region 注入Dbcontext
        public readonly Db db;
        public Repository(IDbContextFactory db)
        {
            this.db = (Db)db.GetContext();
        }
        #endregion

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
           return  db.Set<T>().Where(predicate);
        }

        public T Insert(T o)
        {
            var t = db.Set<T>().Create();
            db.Set<T>().Add(t);
            return t;
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public T Delete(T o)
        {
            return db.Set<T>().Remove(o);
        }

        public Db getDb()
        {
            return db;
        }
    }
}
