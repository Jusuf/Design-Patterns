using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace WU15.DesignPatterns.GenericRepository.Core
{
    public class Repository<TEntity, Tkey> : IRepository<TEntity, Tkey> where TEntity : class
    {
        private readonly DbContext context;

        private readonly DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(Tkey id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Tkey id)
        {
            var entityToRemove = dbSet.Find(id);

            dbSet.Remove(entityToRemove);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity,bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

    }
}
