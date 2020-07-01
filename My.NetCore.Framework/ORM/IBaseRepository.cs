using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM
{
    public interface IBaseRepository<TEntity> : ITransaction where TEntity : class, new()
    {
        bool Insert(TEntity entity);

        Task<bool> InsertAsync(TEntity entity);

        bool Insert(IList<TEntity> list);

        Task<bool> InsertAsync(IList<TEntity> list);

        bool Update(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        bool Update(IList<TEntity> list);

        Task<bool> UpdateAsync(IList<TEntity> list);

        bool DeleteByID(object id);

        Task<bool> DeleteByIDAsync(object id);

        bool DeleteByIds(object[] ids);

        Task<bool> DeleteByIdsAsync(object[] ids);

        bool Delete(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        bool Delete(IList<TEntity> list);

        Task<bool> DeleteAsync(IList<TEntity> list);

        TEntity GetModel(object id);

        Task<TEntity> GetModelAsync(object id);

        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda);

        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount);
        
        IEnumerable<T> SqlQuery<T>(string sql);

        int ExecuteCommand(string sql);

        int ExecuteScale(string sql);
    }
}