using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CakeShop.DataAccess.Data;
using CakeShop.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter = null, string includeproperties = null)
        {
            IQueryable<T> query = dbSet;

            if(filter!=null)
            {
                query = query.Where(filter);
            }

            if(includeproperties!=null)
            {
                foreach(var includeProp in includeproperties.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeproperties = null)
        {
            IQueryable<T> query = dbSet;

            if(filter!=null)
            {
                query = query.Where(filter);
            }

            if(includeproperties!=null)
            {
                foreach(var includeProp in includeproperties.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if(orderby!=null)
            {
                return orderby(query).ToList();
            }

            return query.ToList();
        }

        public T GetT(int id)
        {
            return dbSet.Find(id);
        }

        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}