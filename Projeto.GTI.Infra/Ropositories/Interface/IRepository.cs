using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.GTI.Infra.Ropositories.Interface
{
   public interface IRepository<TEntity>
    {
        Task<IList<TEntity>> GetAll();

        Task<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetById(int id);

        TEntity GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);

        Task<int> Count();

        Task<bool> Existe(Expression<Func<TEntity, bool>> where);

        Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where);

        Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includes);

        Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> orderby,
            params Expression<Func<TEntity, object>>[] includes);

        void Save(TEntity entity);

        void SaveMany(IEnumerable<TEntity> entity);

        void Delete(TEntity entity);

        void DeleteMany(IEnumerable<TEntity> entity);

        void AlterarAsync(TEntity entity);
    }
}
