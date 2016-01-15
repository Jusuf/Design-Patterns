using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.GenericRepository.Core
{
    public interface IRepository<TEntity, in Tkey> : IDisposable
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(Tkey id);

        void Insert(TEntity entity);

        void Delete(Tkey id);

        void Update(TEntity entity);

        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

        void Save();
    }
}
