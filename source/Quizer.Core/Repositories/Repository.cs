using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static Quizer.Core.Extensions.Extention;
using System.Text;
using System.Threading.Tasks;
using Quizer.Core.Extensions;

namespace Quizer.Core.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class, new()
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _table;

        public DbContext Db { get { return this._db; } }
        public  DbSet<T> Table { get { return this._table; } }
        protected Repository(DbContext db) 
        {
            this._db = db;
            this._table = db.Set<T>();
        }

        public T Add(T entity)
        {
            return this._table.Add(entity).Entity;  
        }

        public T Edit(T entity, Action<EntityEntry<T>> rules = null)
        {
            var entry = this._db.Entry(entity);

            if (rules == null)
                goto summary;

            foreach (var propertyInfo in typeof(T).GetProperties().Where(m=> m.IsEditable()))
            {
                entry.Property(propertyInfo.Name).IsModified = false;
            }
            rules(entry);

        summary:            
            entry.State = EntityState.Modified;
            return entity;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var query = this._table.AsQueryable<T>();

            if (expression != null)
            {
                query = query.Where(expression);
            }


            return query;
        }

        public T GetFirst(Expression<Func<T, bool>> expression = null)
        {
            var query = this._table.AsQueryable<T>();

            if (expression != null)
            {
                query = query.Where(expression);
            }


            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            this._table.Remove(entity);
        }
        public int Save()
        {
            return this._db.SaveChanges();
        }
    }
}
