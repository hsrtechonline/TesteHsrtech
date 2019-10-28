using HsrTech.Context;
using HsrTech.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HsrTech.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public virtual void Add(params T[] items)
        {
            using (var context = new HsrTechContext())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Added;
                }
                context.SaveChanges();
            }
        }

        public virtual void AddNoValidate(params T[] items)
        {
            using (var context = new HsrTechContext())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Added;
                }
                context.Configuration.ValidateOnSaveEnabled = false;
                context.SaveChanges();
            }
        }

        public virtual void Delete(params T[] items)
        {
            using (var context = new HsrTechContext())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navProperties)
        {
            List<T> list;
            using (var context = new HsrTechContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                if (navProperties != null)
                {
                    dbQuery = navProperties.Aggregate(dbQuery, (current, include) => current.Include(include));
                }

                foreach (Expression<Func<T, object>> navigationProperty in navProperties)
                {
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }

                list = dbQuery.AsNoTracking().ToList<T>();
            }

            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navProperties)
        {
            List<T> list;
            using (var context = new HsrTechContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navProperties)
                {
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }

                list = dbQuery.AsNoTracking().Where(where).AsQueryable<T>().ToList<T>();
            }

            return list;
        }     
        public virtual T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navProperties)
        {
            T item = null;
            using (var context = new HsrTechContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navProperties)
                {
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }

                item = dbQuery.AsNoTracking().FirstOrDefault(where);
            }

            return item;
        }

        public virtual void Update(params T[] items)
        {
            using (var context = new HsrTechContext())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public void UpdateNoValidate(params T[] items)
        {
            using (var context = new HsrTechContext())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Modified;
                }
                context.Configuration.ValidateOnSaveEnabled = false;
                context.SaveChanges();
            }
        }
    }
}
