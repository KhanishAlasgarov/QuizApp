﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class, new()
    {
        private readonly DbContext db;
        private readonly DbSet<T> _table;
        protected Repository(DbContext db)
        {
            this.db = db;
            _table = db.Set<T>();
        }
        protected DbContext Db { get => db; }
        protected DbSet<T> Table { get => _table; }
        public T Add(T entity)
        {
            _table.Add(entity);
            return entity;
        }

        public T Edit(T entity, EntityEntry<T> rules = null)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> expression = null)
        {
            return _table.FirstOrDefault(expression != null ? expression : null);
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return _table.Where(expression!=null?expression:null).AsQueryable();
        }

        public void Remove(T entity)
        {
            _table.Remove(entity);
        }

        public int Save()
        {
            
            returndb.SaveChanges();
        }
    }
}
